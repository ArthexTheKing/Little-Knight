using UnityEngine;

public class MeleeAttackState : AttackState
{
    private Movement Movement => movement != null ? movement : core.GetCoreComponent(ref movement);

    private Movement movement;

    protected D_MeleeAttack stateData;

    public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData) : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider2D[] delectedObject = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

        foreach (Collider2D collider in delectedObject)
        {
            if(collider.TryGetComponent(out IDamageble damageble))
            {
                damageble.Damage(stateData.attackDamage);
            }

            if (collider.TryGetComponent(out IKnockBackable knockbackable))
            {
                knockbackable.KnockBack(stateData.knockbackAngle, stateData.knockbakcStrenght, Movement.FacingDirection);
            }
        }
    }
}
