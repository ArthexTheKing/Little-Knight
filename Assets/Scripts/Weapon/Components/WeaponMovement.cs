using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : WeaponComponent<WeaponMovementData, AttackMovement>
{
    private CoreComp<Movement> movement;

    private void HandleStartMovement()
    {
        movement.Comp.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, movement.Comp.FacingDirection);
    }

    private void HandleStopMovement()
    {
        movement.Comp.SetVelocityZero();
    }

    protected override void Start()
    {
        base.Start();

        movement = new(Core);

        eventHandler.OnStartMovement += HandleStartMovement;
        eventHandler.OnStopMovement += HandleStopMovement;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        eventHandler.OnStartMovement -= HandleStartMovement;
        eventHandler.OnStopMovement -= HandleStopMovement;
    }
}
