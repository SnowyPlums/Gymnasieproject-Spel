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
            Selector.transform.localPosition = new Vector3(Selector.transform.localPosition.x, Play.transform.localPosition.y, Selector.transform.localPosition.z);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Selector.transform.localPosition = new Vector3(Selector.transform.localPosition.x, Exit.transform.localPosition.y, Selector.transform.localPosition.z);

        }
        else if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Level1");
            GameBoard.playerScore = 0;
        }
    }
}
