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

    protected override void Awake()
    {
        base.Awake();

        hitBox = GetComponent<WeaponActionHitBox>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        hitBox.OnDetectedCollider2D += HandleDetectCollider2D;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
    }



}
