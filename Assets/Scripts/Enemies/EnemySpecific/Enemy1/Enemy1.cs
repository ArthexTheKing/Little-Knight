using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_PlayerDetectedState playerDetectedState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }
    public E1_MeleeAttackState meleeAttackState { get; private set; }
    public E1_StunState stunState { get; private set; }
    public E1_DeadState deadState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    private D_DeadState deadStateData;

    public override void Awake()
    {
        base.Awake();

        moveState = new E1_MoveState(this, StateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, StateMachine, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetectedState(this, StateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new E1_ChargeState(this, StateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new E1_LookForPlayerState(this, StateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new E1_MeleeAttackState(this, StateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        stunState = new E1_StunState(this, StateMachine, "stun", stunStateData, this);
        deadState = new E1_DeadState(this, StateMachine, "dead", deadStateData, this);
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

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if(isDead)
        {
            StateMachine.ChangeState(deadState);
        }
        else if (isStunned && StateMachine.currentState != stunState)
        {
            StateMachine.ChangeState(stunState);
        }
    }
}
