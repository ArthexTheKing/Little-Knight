using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{
    public E2_MoveState moveState { get; private set; }
    public E2_IdleState idleState { get; private set; }
    public E2_PlayerDetectedState playerDetectedState { get; private set; }
    public E2_MeleeAttackState meleeAttackState { get; private set; }
    public E2_LookForPlayerState lookForPlayerState { get; private set; }
    public E2_StunState stunState { get; private set; }
    public E2_DeadState deadState { get; private set; }
    public E2_DodgeState dodgeState { get; private set; }
    public E2_RangedAttackState rangedAttackState { get; private set; }

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    public D_DodgeState dodgeStateData;
    [SerializeField]
    private D_RangedAttackState rangedAttackStateData;

    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    private Transform rangedAttackPosition;

    public override void Awake()
    {
        base.Awake();

        moveState = new E2_MoveState(this, StateMachine, "move", moveStateData, this);
        idleState = new E2_IdleState(this, StateMachine, "idle", idleStateData, this);
        playerDetectedState = new E2_PlayerDetectedState(this, StateMachine, "playerDetected", playerDetectedStateData, this);
        meleeAttackState = new E2_MeleeAttackState(this, StateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        lookForPlayerState = new E2_LookForPlayerState(this, StateMachine, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new E2_StunState(this, StateMachine, "stun", stunStateData, this);
        deadState = new E2_DeadState(this, StateMachine, "dead", deadStateData, this);
        dodgeState = new E2_DodgeState(this, StateMachine, "dodge", dodgeStateData, this);
        rangedAttackState = new E2_RangedAttackState(this, StateMachine, "rangedAttackState", rangedAttackPosition, rangedAttackStateData, this);
    }

    public override void Start()
    {
        base.Start();

        StateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}
