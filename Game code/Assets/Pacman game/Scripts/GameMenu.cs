using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

	public Text Play;
	public Text Exit;
	public Text Selector;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            SceneManager.LoadScene("Level1");
            GameBoard.playerScore = 0;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }
}
