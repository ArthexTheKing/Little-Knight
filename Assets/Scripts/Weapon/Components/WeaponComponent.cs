using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponComponent : MonoBehaviour
{
    protected Weapon weapon;

    protected Core Core => weapon.Core;

    //protected AnimationEventHandler EventHandler => weapon.EventHandler;

    protected AnimationEventHandler eventHandler;

    protected bool isAttackActive;

    protected virtual void Awake() 
    {
        weapon = GetComponent<Weapon>();

        eventHandler = GetComponentInChildren<AnimationEventHandler>();
    }

    protected virtual void HandleEnter()
    {
        isAttackActive = true;
    }

    protected virtual void HandleExit()
    {
        isAttackActive = false;
    }

    protected virtual void OnEnable()
    {
        weapon.OnEnter += HandleEnter;
        weapon.OnExit += HandleExit;
    }

    protected virtual void OnDisable()
    {
        weapon.OnEnter -= HandleEnter;
        weapon.OnExit -= HandleExit;
    }

}
