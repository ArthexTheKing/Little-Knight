using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement => GenericNotImplementedError<Movement>.TryGet(movement, transform.parent.name);
    public CollisionSenses CollisionSenses => GenericNotImplementedError<CollisionSenses>.TryGet(collisionSenses, transform.parent.name);
    public Combat Combat => GenericNotImplementedError<Combat>.TryGet(combat, transform.parent.name);
    public Stats Stats => GenericNotImplementedError<Stats>.TryGet(stats, transform.parent.name);

    private Movement movement;
    private CollisionSenses collisionSenses;
    private Combat combat;
    private Stats stats;

    private readonly List<ILogicUpdate> components = new();

    private void Awake()
    {
        movement = GetComponentInChildren<Movement>();
        collisionSenses = GetComponentInChildren<CollisionSenses>();
        combat = GetComponentInChildren<Combat>();
        stats = GetComponentInChildren<Stats>();
    }

    public void LogicUpdate()
    {
        foreach (ILogicUpdate component in components)
        {
            component.LogicUpdate();
        }
    }

    public void AddComponent(ILogicUpdate component)
    {
        
        if (!components.Contains(component))
        {
            components.Add(component);
        }
    }
}
