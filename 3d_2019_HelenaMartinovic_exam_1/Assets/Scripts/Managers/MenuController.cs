using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    Button btnNewGame;
    Button btnExitGame;

    void Start()
    {
        btnNewGame = GameObject.Find(StringConstants.BtnUI.Again)?.GetComponent<Button>();
        btnExitGame = GameObject.Find(StringConstants.BtnUI.Exit)?.GetComponent<Button>();

        btnNewGame?.onClick.AddListener(() => NewGame());
        btnExitGame?.onClick.AddListener(() => ExitGame());
    }

    void NewGame(){
        MySceneManager.LoadScene(SceneType.Level1);
    }

    void ExitGame(){
        Application.Quit();
    }
}
