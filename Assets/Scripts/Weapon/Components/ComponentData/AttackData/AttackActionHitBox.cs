using System;
using UnityEngine;

[Serializable]
public class AttackActionHitBox : AttackData
{
    public bool debug;
    
    [field: SerializeField] public Rect HitBox { get; private set; }
}
