using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class BackToSelection : MonoBehaviour
{
    private void Awake()
    {
        transform.Find("backBtn").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(Loader.Scene.MainMenu);
        };
    }
}
