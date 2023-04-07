public class PlayerAbilityState : PlayerState
{
    protected Movement Movement => movement != null ? movement : core.GetCoreComponent(ref movement);

    private CollisionSenses CollisionSenses => collisionSenses != null ? collisionSenses : core.GetCoreComponent(ref collisionSenses);

    protected bool isAbilityDone;

    private Movement movement;
    private CollisionSenses collisionSenses;

    private bool isGrounded;

    public PlayerAbilityState(Player player, string animBoolName) : base(player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        isAbilityDone = false;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        if (CollisionSenses)
        {
            isGrounded = CollisionSenses.Grounded;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAbilityDone)
        {
            if(isGrounded && Movement?.CurrentVelocity.y < 0.01f)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }
}