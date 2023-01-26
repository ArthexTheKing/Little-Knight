using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement
    { 
        get
        {
            if (movement) return movement;
            Debug.LogError("No Movement Core Component on " + transform.parent.name);
            return null;
        }
    }
    public CollisionSenses CollisionSenses
    { 
        get
        {
            if (collisionSenses) return collisionSenses;
            Debug.LogError("No Collision Sense Core Component on " + transform.parent.name);
            return null;
        }
    }

    private Movement movement;
    private CollisionSenses collisionSenses;

    private void Awake()
    {
        movement = GetComponentInChildren<Movement>();
        collisionSenses = GetComponentInChildren<CollisionSenses>();
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
    }
}
