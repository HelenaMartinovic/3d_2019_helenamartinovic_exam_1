using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;
    Vector3 position;

    // Update is called once per frame
    void LateUpdate(){
        position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = position;
    }
}
