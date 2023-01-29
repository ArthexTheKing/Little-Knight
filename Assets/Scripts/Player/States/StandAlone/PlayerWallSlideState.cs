public class PlayerWallSlideState : PlayerState
{
    private Movement Movement => movement != null ? movement : core.GetCoreComponent(ref movement);

    private CollisionSenses CollisionSenses => collisionSenses != null ? collisionSenses : core.GetCoreComponent(ref collisionSenses);

    private Movement movement;
    private CollisionSenses collisionSenses;

    private int xInput;

    private bool isGrounded;
    private bool isTouchingWall;
    private bool jumpInput;
    
    public PlayerWallSlideState(Player player, SO_PlayerData playerData, PlayerStateMachine stateMachine, string animBoolName) : base(player, playerData, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        if (CollisionSenses)
        {
            isGrounded = CollisionSenses.Grounded;
            isTouchingWall = CollisionSenses.WallFront;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;

        if(!isExitingState)
        {
            if (jumpInput)
            {
                player.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
                stateMachine.ChangeState(player.WallJumpState);
            }
            else if (isGrounded)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (!isTouchingWall || xInput != Movement?.FacingDirection)
            {
                stateMachine.ChangeState(player.InAirState);
            }
            else
            {
                Movement?.SetVelocityY(-playerData.wallSlideVelocity);
            }
        }
    }
}