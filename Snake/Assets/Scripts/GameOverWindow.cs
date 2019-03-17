using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameOverWindow : MonoBehaviour
{
    private void Awake()
    {
        transform.Find("retryBtn").GetComponent<Button_UI>().ClickFunc = () =>{
            Loader.Load(Loader.Scene.GameScene);
        };
    }
}
