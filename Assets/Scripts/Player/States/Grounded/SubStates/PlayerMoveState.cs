using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    #region Constructors

    public PlayerMoveState(Player player, string animBoolName) : base(player, animBoolName)
    {
    }

    #endregion

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.SetVelocityX(playerData.movementVelocity * xInput);

        if (!isExitingState)
        {
            if (xInput == 0 || isTouchingWall)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (yInput == -1)
            {
                stateMachine.ChangeState(player.CrouchMoveState);
            }
        }
    }
}