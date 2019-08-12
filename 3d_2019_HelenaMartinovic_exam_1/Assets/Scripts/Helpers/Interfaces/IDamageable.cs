using UnityEngine;

internal interface IDamageable
{
    void FallDamage();
    void ReceiveDamage(int damage, Vector3 damagePoint);
    void GetLife(int life);
}