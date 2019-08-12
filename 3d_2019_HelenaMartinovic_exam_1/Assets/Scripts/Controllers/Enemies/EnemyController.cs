using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 position;
    float x;
    float speed;
    int direction;
    bool dying;
    bool inited;

    Transform meshTransform;
    Animator animator;
    AudioSource dyingAudio;

    void Start(){
        direction = 1;
        speed = 2f;
        dying = false;
        inited = true;

        meshTransform = transform.GetChild(0);
        animator = meshTransform.GetComponent<Animator>();
        dyingAudio = GetComponent<AudioSource>();
    }

    void Update(){
        if(dying) return;
        x = transform.position.x + (speed * Time.deltaTime * direction);
        position = new Vector3(x, transform.position.y, transform.position.z);
        transform.position = position;
    }

    void OnCollisionEnter(Collision collision){
        if(!inited) return;
        if(dying) return;

        IDamageable damageableObject = collision.collider.GetComponent<IDamageable>();
        if(damageableObject != null){
            damageableObject.ReceiveDamage(ScoreConstants.EnemyDamage, transform.position);
         }

        direction *= -1;
        meshTransform.eulerAngles = new Vector3(0, 90, 0) * direction;
    }

    void OnTriggerEnter(Collider collider){
        if(dying) return;
        IPickup pickup = collider.GetComponent<IPickup>();

        if(pickup != null){
            pickup.AddPoints(ScoreConstants.EnemyKill);

            Collider[] colliders = GetComponentsInChildren<Collider>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }


            animator.SetTrigger("die");
            dyingAudio.Play();

            GameObject.Destroy(this.gameObject, 1f);
            dying = true;
        }
    }

    public void Die(){
        var player = GameObject.FindGameObjectWithTag("Player");

        if(player != null){
            var pickup = player.GetComponent<IPickup>();

            if(pickup != null){
                pickup.AddPoints(ScoreConstants.EnemyKill);
            }
        }

        animator.SetTrigger("die");
        dyingAudio.Play();

        GameObject.Destroy(this.gameObject, 1f);
        dying = true;
    }
}