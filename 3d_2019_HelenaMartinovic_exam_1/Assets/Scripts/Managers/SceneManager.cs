using UnityEngine.SceneManagement;
using UnityEngine;

public static class MySceneManager
{
    public static void LoadScene(SceneType scene){
        SceneManager.LoadScene(scene.ToString());

        if(scene == SceneType.Level1){
            StatusesManager.Score = 0;
            StatusesManager.Health = 5;
        }
        else if(scene == SceneType.Level2){
            var player = (PlayerController)GameObject.FindObjectOfType(typeof(PlayerController));

            if(player != null)
            {
                StatusesManager.Score = player.GetPlayerCoins();
                StatusesManager.Health = player.GetPlayerHealth();
            }
        }
    }
}
