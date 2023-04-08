using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : WeaponComponent<WeaponMovementData, AttackMovement>
{
    private Movement movement;
    private Movement Movement => Core.GetCoreComponent(ref movement);

    private void HandleStartMovement()
    {
        Movement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, Movement.FacingDirection);
    }

    private void HandleStopMovement()
    {
        Movement.SetVelocityZero();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        eventHandler.OnStartMovement += HandleStartMovement;
        eventHandler.OnStopMovement += HandleStopMovement;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        eventHandler.OnStartMovement -= HandleStartMovement;
        eventHandler.OnStopMovement -= HandleStopMovement;
    }
}
