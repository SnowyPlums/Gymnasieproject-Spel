using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour {

    public void TetrisRestart ()
    {
        SceneManager.LoadScene("Level");
    }
    public void StartPacman()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void Quitgame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Snake()
    {
        SceneManager.LoadScene("GameScene");
    }
}
