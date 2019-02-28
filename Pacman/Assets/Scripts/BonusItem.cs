using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : MonoBehaviour {

	float randomLifeExpectancy;
	float currentLifeTime;

	// Use this for initialization
	void Start () {

		randomLifeExpectancy = Random.Range (9f, 10f);

		Debug.Log ("Life Expectancy: " + randomLifeExpectancy);

		this.name = "bonusItem";

		GameObject.Find ("Game").GetComponent <GameBoard> ().board [14, 13] = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if (currentLifeTime < randomLifeExpectancy) {

			currentLifeTime += Time.deltaTime;

		} else {

			Destroy (this.gameObject);
		}
	}
}
