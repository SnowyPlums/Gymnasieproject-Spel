using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour {

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int health;
    public float invincible;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    //[HideInInspector]
    //public Collider2D[] myColls;
	
    //void Start()
    //{
        //myColls = this.GetComponents<Collider2D>();
    //}

	void Update () {

        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                timeBtwAttack = startTimeBtwAttack;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().health -= damage;
                }
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
	}
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void Hurt()
    {
        health -= 20;
        if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            TriggerHurt(invincible);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            Hurt();
        }
    }

    public void TriggerHurt(float invincible)
    {
        StartCoroutine(HurtBlinker(invincible));
    }

    IEnumerator HurtBlinker(float invincible)
    {
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);
        //foreach (Collider2D collider in myColls)
        //{
            //collider.enabled = false;
            //collider.enabled = true;
        //}

        yield return new WaitForSeconds(invincible);

        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
    }
}
