using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathZoneController : MonoBehaviour//todo rename u nesto poput scene changer
{

    Animator animator;
    Image fadeImage;

    void Start(){
        fadeImage = null;
    }

    void OnTriggerEnter(Collider collider){
        var playerController = collider.GetComponent<PlayerController>();

        if(playerController == null){
            return;
        }

        MySceneManager.LoadScene(SceneType.Level1);
    }

    void FadeInScreen(){
        animator.SetTrigger(StringConstants.AnimatorEvents.FadeOut);
    }

}
