using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public bool isFirstLevel = true;
    private int perfectScore = 50;

    void OnTriggerEnter(Collider collider){
        var player = collider.GetComponent<PlayerController>();

        if(player == null){
            return;
        }

        if(isFirstLevel){
            MySceneManager.LoadScene(SceneType.Level2);
        }
        else{
            var consValue = player.GetPlayerCoins(); 
            if(consValue > perfectScore){
                MySceneManager.LoadScene(SceneType.BahamasEnd);
            }
            else{
                MySceneManager.LoadScene(SceneType.RegularWinScene);
            }
        }
        
    }
}
