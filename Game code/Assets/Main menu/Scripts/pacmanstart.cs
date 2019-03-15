using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pacmanstart : MonoBehaviour
{

    public void Startgame()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
