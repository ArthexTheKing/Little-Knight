using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponKnockBack : WeaponComponent<WeaponKnockBackData, AttackKnockBack>
{
    private WeaponActionHitBox hitBox;
    private CoreComp<Movement> movement;

    private void HandleDetectCollider2D(Collider2D[] colliders)
    {
        foreach (var item in colliders)
        {
            if (item.TryGetComponent(out IKnockBackable knockBackable))
            {
                knockBackable.KnockBack(currentAttackData.Angle, currentAttackData.Strenght, movement.Comp.FacingDirection);
            }
        }
    }

    protected override void Start()
    {
        base.Start();

        movement = new(Core);

        hitBox = GetComponent<WeaponActionHitBox>();
        hitBox.OnDetectedCollider2D += HandleDetectCollider2D;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
    }
}
