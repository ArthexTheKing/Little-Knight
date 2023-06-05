using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Movement Movement => movement != null ? movement : core.GetCoreComponent(ref movement);

    private CollisionSenses CollisionSenses => collisionSenses != null ? collisionSenses : core.GetCoreComponent(ref collisionSenses);

    protected int xInput;
    protected int yInput;
    protected bool isTouchingWall;
    protected bool isTouchingCeiling;

    private Movement movement;
    private CollisionSenses collisionSenses;

    private bool jumpInput;
    private bool isGrounded;

    public PlayerGroundedState(Player player, string animBoolName) : base(player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpsLeft();
    }

    public override void DoChecks()
    {
        base.DoChecks();

        if (CollisionSenses)
        {
            isGrounded = CollisionSenses.Grounded;
            isTouchingWall = CollisionSenses.WallFront;
            isTouchingCeiling = CollisionSenses.Ceiling;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        jumpInput = player.InputHandler.JumpInput;

        Movement?.CheckIfShouldFlip(xInput);

        if (!isTouchingCeiling)
        {
            if (player.InputHandler.AttackInput)
            {
                stateMachine.ChangeState(player.AttackState);
            }
            else if (jumpInput && player.JumpState.CanJump())
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (!isGrounded)
            {
                player.InAirState.StartCoyoteTime();
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }
}