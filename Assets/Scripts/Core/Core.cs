using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement => GenericNotImplementedError<Movement>.TryGet(movement, transform.parent.name);
    public CollisionSenses CollisionSenses => GenericNotImplementedError<CollisionSenses>.TryGet(collisionSenses, transform.parent.name);
    public Combat Combat => GenericNotImplementedError<Combat>.TryGet(combat, transform.parent.name);

    private Movement movement;
    private CollisionSenses collisionSenses;
    private Combat combat;

    private void Awake()
    {
        movement = GetComponentInChildren<Movement>();
        collisionSenses = GetComponentInChildren<CollisionSenses>();
        combat = GetComponentInChildren<Combat>();
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
        Combat.LogicUpdate();
    }
}
