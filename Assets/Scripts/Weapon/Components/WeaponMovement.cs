using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : WeaponComponent
{
    private Movement movement;
    private Movement Movement => Core.GetCoreComponent(ref movement);

    private WeaponMovementData data;

    private void HandleStartMovement()
    {
        var currentAttackData = data.AttackData[weapon.CurrentAttackCounter];

        Movement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, Movement.FacingDirection);
    }

    private void HandleStopMovement()
    {
        Movement.SetVelocityZero();
    }

    protected override void Awake()
    {
        base.Awake();

        data = weapon.Data.GetData<WeaponMovementData>();
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
