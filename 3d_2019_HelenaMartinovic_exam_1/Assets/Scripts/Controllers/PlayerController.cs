using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable, IPickup {

	const float fireballDelay = 1f;

	PlayerStats stats;
	CharacterController controller;
	Animation powerupAnimation;
	Animation characterAnimation;
	Vector3 motion;
	int direction;
	new Rigidbody rigidbody;

	[HideInInspector]
	public IPlayerAudio playerAudio;

	bool isFireballPower;
	bool isExtraLifePower;
	float fireballTime = 0f; 
	Vector3 hitJump;

    // Use this for initialization
    void Start () {
		controller = this.GetComponent<CharacterController>();
		powerupAnimation = this.GetComponentInChildren<Animation>();
		characterAnimation = transform.GetChild(0).GetComponent<Animation>();
		rigidbody= GetComponent<Rigidbody>();

		stats = new PlayerStats();
		stats.lives = StatusesManager.Health;
		stats.totalScore = StatusesManager.Score;
		motion = Vector3.zero;
		hitJump = Vector3.zero;

		isFireballPower = false;
		isExtraLifePower = false;
		direction = 1;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove();
		StatusesManager.getInstance().UpdateUI(stats);
	}

	void PlayerMove(){
		float x = 0, y = 0;
		float initialZ = transform.position.z;

		bool playRun = false;
		if(Input.GetKey(PlayerInput.left)){
			direction = -1;
			x = direction * stats.movementSpeed * Time.deltaTime;
			characterAnimation.gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
			playRun = true;
		}
		else if(Input.GetKey(PlayerInput.right)){
			direction = 1;
			x = stats.movementSpeed * Time.deltaTime;
			characterAnimation.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
			playRun = true;
		}
		
		if(isFireballPower){
			fireballTime += Time.deltaTime;

			if (Input.GetKey(PlayerInput.shooting)){
				Fireball();
			}
		}
		if(controller.isGrounded && Input.GetKey(PlayerInput.crouch)){
			Debug.Log("animation");
			x *= stats.crouchSpeed;
		}

        y = motion.y;
        motion = new Vector3(x, 0, 0);
        motion =  Vector3.Normalize(motion);

        motion.x *= stats.movementSpeed;
        motion.y = y;
        
        motion = transform.TransformDirection(motion);

		if(controller.isGrounded && Input.GetKeyDown(PlayerInput.jump)){
			motion.y = stats.jumpSpeed;

			playerAudio.Jump();
			playRun = true;
		}
        
        motion.y = motion.y - (stats.gravity * Time.deltaTime);
        controller.Move(motion * Time.deltaTime);

		characterAnimation.Play(playRun ? "Run" : "Dizzy");
		var pos = transform.position;
		pos.z = initialZ;
		transform.position = pos;
	}
	
    public void GetLife(int life) {
        stats.lives += life;
    }

    public void ReceiveDamage(int damage, Vector3 damagePoint) {
		if(isFireballPower){
			if(isExtraLifePower){
				powerupAnimation.Play("PlayerPowerupIn");				
			}
			else{
				powerupAnimation.Play("PlayerFireOut");
			}
			isFireballPower = false;
			return;
		}
		else if(isExtraLifePower){
			powerupAnimation.Play("PlayerPowerupOut");
			isExtraLifePower = false;
			return;
		}
		
        stats.lives -= damage;


		if(stats.lives <= 0) {
			MySceneManager.LoadScene(SceneType.GameOver);
		}

		hitJump = (transform.position - damagePoint + Vector3.up) * 0.5f;
    }
 
	public void FallDamage(){
		stats.lives -= ScoreConstants.FallDamage;
	}

	public void Fireball(){

		if(fireballTime <= fireballDelay){
			return;
		}
		playerAudio.Fireball();
		
		var tmpResourceFireball = Resources.Load<GameObject>(StringConstants.Prefabs.Fireball);
		var fireballObj = GameObject.Instantiate(tmpResourceFireball, this.transform.position + Vector3.right * direction, this.transform.rotation);
		fireballObj.GetComponent<FireballController>().setDirection(direction);

		Debug.Log("Shoot");
		fireballTime = 0;
	}

    public void AddCoins(int coin){
        stats.totalScore += coin;
		playerAudio.Coin();
    }

    public void AddPowerup(PowerupType powerup){
		if(powerup == PowerupType.Fireball){
			powerupAnimation.Play("PlayerFireIn");
			isFireballPower = true;
		}
		else if(powerup == PowerupType.ExtraHealth){
			if(!isFireballPower){
				powerupAnimation.Play();
			}
			isExtraLifePower = true;
		};

		playerAudio.PowerupPickup();
    }

    public void AddPoints(int point){
        stats.totalScore += point;
    }

	public int GetPlayerCoins(){
		return stats.totalScore;
	}

	public int GetPlayerHealth(){
		return stats.lives;
	}
}
