using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAudio
{
    void Jump();
    void Fireball();
    void PowerupPickup();
    void PowerupAppear();
    void Coin();
    void Die();
}
