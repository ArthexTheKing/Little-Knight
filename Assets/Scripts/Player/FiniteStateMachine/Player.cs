using UnityEngine;

public class Player : MonoBehaviour {
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerLedgeClimbState LedgeClimbState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerCrouchMoveState CrouchMoveState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }

    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D MovementCollider { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    
    [field: SerializeField] public PlayerDataSO PlayerDataSO { get; private set; }

    private Weapon weapon;

    private void Awake() {
        Core = GetComponentInChildren<Core>();

        weapon = transform.Find("Weapon").GetComponent<Weapon>();

        weapon.SetCore(Core);

        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, "idle");
        MoveState = new PlayerMoveState(this, "move");
        JumpState = new PlayerJumpState(this, "inAir");
        InAirState = new PlayerInAirState(this, "inAir");
        LandState = new PlayerLandState(this, "land");
        WallSlideState = new PlayerWallSlideState(this, "wallSlide");
        WallJumpState = new PlayerWallJumpState(this, "inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, "ledgeClimbState");
        CrouchIdleState = new PlayerCrouchIdleState(this, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, "crouchMove");
        AttackState = new PlayerAttackState(this, "attack", weapon);
    }

    private void Start() {
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>(); 
        InputHandler = GetComponent<PlayerInputHandler>();
        MovementCollider = GetComponent<BoxCollider2D>();

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    public void SetColliderHeight(float height)
    {
        Vector2 center = MovementCollider.offset;
        Vector2 workspace = new(MovementCollider.size.x, height);

        center.y += (height - MovementCollider.size.y) / 2;

        MovementCollider.size = workspace;
        MovementCollider.offset = center;
    }

}
