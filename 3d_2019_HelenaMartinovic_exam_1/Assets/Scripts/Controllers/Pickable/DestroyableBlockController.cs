using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBlockController : MonoBehaviour
{
    private IPlayerAudio audio;
    
    public GameObject objectToShowAfterDestroy;

    void Start(){
        audio = AudioManager.Instance;
    }

    void OnTriggerEnter(Collider collider){
        var pickapable = collider.GetComponent<IPickup>();
        
        if(pickapable == null){
            return;
        }

        pickapable.AddPoints(ScoreConstants.BlockScore);
        if(objectToShowAfterDestroy != null){
            objectToShowAfterDestroy.SetActive(true);
            audio.PowerupAppear();
        }

        GameObject.Destroy(this.gameObject, 0.01f);
    }
}
