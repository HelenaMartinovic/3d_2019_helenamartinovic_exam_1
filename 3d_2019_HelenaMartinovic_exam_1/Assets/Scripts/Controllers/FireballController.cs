using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    const float destroyTime = 3f;
    float currentTime;
    float speed;
    int direction;

    Vector3 moveForce;
    Rigidbody rb;

    public void setDirection(int direction)
    {
        this.direction = direction;
    }

    void Start()
    {
        speed = 700;
        currentTime = 0;

        rb = GetComponent<Rigidbody>();

        moveForce = Vector3.right * direction;
        moveForce.z = 0;

        moveForce *= speed;

        rb.AddForce(moveForce);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= destroyTime)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision){
        var enemy = collision.gameObject.GetComponent<EnemyController>();

        if(enemy == null){
            return;
        }

        enemy.Die();
        GameObject.Destroy(this.gameObject);
    }
}