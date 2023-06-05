public class PlayerAttackState : PlayerAbilityState {

    private Weapon weapon;

    public PlayerAttackState(Player player, string animBoolName, Weapon weapon) : base(player, animBoolName)
    {
        this.weapon = weapon;

        weapon.OnExit += ExitHandler;
    }

    public override void Enter()
    {
        base.Enter();

        weapon.Enter();
    }

    private void ExitHandler() 
    {
        AnimationFinishTrigger();
        isAbilityDone = true;
    }

}