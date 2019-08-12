using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : IPlayerAudio
{
    AudioClip _jump;
    AudioClip _coin;
    AudioClip _gameOver;
    AudioClip _fireball;
    AudioClip _powerupApper;
    AudioClip _powerupPickup;
    AudioClip _stomp;
    AudioClip _enterLevel;
    AudioSource _audioSource;
    
    static AudioManager _instance;

    public static AudioManager Instance{
        get{
            if(_instance == null){
                _instance = new AudioManager();
            }

            return _instance;
        }
    }

    AudioSource AudioSourceInstance{
        get{
            if(_audioSource == null){
                _audioSource = GameObject.Find(StringConstants.Audio.AudioSourceObject).GetComponent<AudioSource>();
            }

            return _audioSource;
        }
    }

    public AudioManager(){
    }

    public void Jump(){
        if(_jump == null){
            _jump =  Resources.Load<AudioClip>(StringConstants.Audio.Jump);
        }

        AudioSourceInstance.clip = _jump;
        AudioSourceInstance.Play();
    }

    public void Fireball(){
        if(_fireball == null){
            _fireball =  Resources.Load<AudioClip>(StringConstants.Audio.Fireball);
        }

        AudioSourceInstance.clip = _fireball;
        AudioSourceInstance.Play();
    }

    public void PowerupPickup(){
        if(_powerupPickup == null){
            _powerupPickup =  Resources.Load<AudioClip>(StringConstants.Audio.PowerupPickup);
        }

        AudioSourceInstance.clip = _powerupPickup;
        AudioSourceInstance.Play();
    }

    public void Coin(){
        if(_coin == null){
            _coin =  Resources.Load<AudioClip>(StringConstants.Audio.Coin);
        }

        AudioSourceInstance.clip = _coin;
        AudioSourceInstance.Play();
    }

    public void Die(){
        if(_gameOver == null){
            _gameOver = Resources.Load<AudioClip>(StringConstants.Audio.GameOver);
        }

        AudioSourceInstance.clip = _gameOver;
        AudioSourceInstance.Play();
    }

    public void PowerupAppear(){
        if(_powerupApper == null){
            _powerupApper = Resources.Load<AudioClip>(StringConstants.Audio.PowerupAppear);
        }

        AudioSourceInstance.clip = _powerupApper;
        AudioSourceInstance.Play();
    }
}