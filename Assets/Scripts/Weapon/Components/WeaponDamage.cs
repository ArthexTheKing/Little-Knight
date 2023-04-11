using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : WeaponComponent<WeaponDamageData, AttackDamage>
{
    private WeaponActionHitBox hitBox;

    private void HandleDetectCollider2D(Collider2D[] colliders)
    {
        foreach (var item in colliders)
        {
            if (item.TryGetComponent(out IDamageble damagable))
            {
                damagable.Damage(currentAttackData.Amount);
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        hitBox = GetComponent<WeaponActionHitBox>();
        hitBox.OnDetectedCollider2D += HandleDetectCollider2D;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
    }



}
