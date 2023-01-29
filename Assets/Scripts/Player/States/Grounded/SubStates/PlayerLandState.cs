public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, SO_PlayerData playerData, PlayerStateMachine stateMachine, string animBoolName) : base(player, playerData, stateMachine, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            if(xInput != 0 && !isTouchingWall)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else if(isAnimationFinished)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }
}