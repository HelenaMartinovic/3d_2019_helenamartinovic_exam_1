using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieryPowerupController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        IPickup pickup = collision.transform.GetComponent<IPickup>();
        
        if(pickup != null){
            pickup.AddPoints(ScoreConstants.HiddenPowerupScore);
            pickup.AddPowerup(PowerupType.Fireball);
            Destroy(this.gameObject, 0.01f);
        }
    }
}
