using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickup
{
    void AddPoints(int point);
    void AddCoins(int coin);
    void AddPowerup(PowerupType powerup);
}
