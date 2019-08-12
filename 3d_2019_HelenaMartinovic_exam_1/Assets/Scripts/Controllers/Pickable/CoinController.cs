using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        var player = collider.GetComponent<IPickup>();
        
        if(player == null){
            return;
        }

        player.AddCoins(ScoreConstants.CoinScore);
        GameObject.Destroy(this.gameObject, 0.01f);        
    }
}