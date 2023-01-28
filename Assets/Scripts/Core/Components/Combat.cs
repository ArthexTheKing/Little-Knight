using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageble, IKnockbackable
{
    public void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + " damaged!");
    }

    public void Knockback(Vector2 angle, float strenght, int direction)
    {
        core.Movement.SetVelocity(strenght, angle, direction);
    }
}
