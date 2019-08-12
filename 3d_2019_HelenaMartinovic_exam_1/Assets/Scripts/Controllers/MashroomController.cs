using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashroomController : MonoBehaviour
{
    Vector3 moveForce;
    float speed;
    Rigidbody rb;

    bool addRightForce;
    bool addedInitialForce;

    void Start(){
        addedInitialForce = false;
        speed = 8f;

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        moveForce = Vector3.down;

        if(!addedInitialForce){
            moveForce = Vector3.up * 30f + Vector3.right * 30f;
            addedInitialForce = true;
        }

        if(addRightForce){
            moveForce += Vector3.right * 2;
        }

        moveForce *= speed;

        rb.AddForce(moveForce);
    }

    void OnCollisionEnter(Collision collision) {
        IPickup pickup = collision.collider.GetComponent<IPickup>();
        if(pickup != null){
            pickup.AddPoints(ScoreConstants.PowerupScore);
            pickup.AddPowerup(PowerupType.ExtraHealth);
            GameObject.Destroy(this.gameObject, 0.01f);
        }

    }

    void OnCollisionStay()
    {
        addRightForce = true;
    }
    
    void OnCollisionExit()
    {
        addRightForce = false;
    }
}
