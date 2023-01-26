using UnityEngine;

public class CollisionSenses : CoreComponent
{
    public Transform GroundCheck { get => groundCheck; }
    public Transform WallCheck { get => wallCheck; }
    public Transform LedgeCheckHorizontal { get => ledgeCheckHorizontal; }
    public Transform LedgeCheckVertical { get => ledgeCheckVertical; }
    public Transform CeilingCheck { get => ceilingCheck; }

    public float GroundCheckRadius { get => collisionSensesData.groundCheckRadius; }
    public float WallCheckDistance { get => collisionSensesData.wallCheckDistance; }
    public LayerMask WhatIsGround { get => collisionSensesData.whatIsGround; }

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheckHorizontal;
    [SerializeField] private Transform ledgeCheckVertical;
    [SerializeField] private Transform ceilingCheck;

    [SerializeField] private SO_CollisionSensesData collisionSensesData;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, collisionSensesData.groundCheckRadius);
        Gizmos.DrawWireSphere(ceilingCheck.position, collisionSensesData.groundCheckRadius);
        Gizmos.DrawRay(wallCheck.position, new Vector3(collisionSensesData.wallCheckDistance, 0f, 0f));
        Gizmos.DrawRay(wallCheck.position, new Vector3(-collisionSensesData.wallCheckDistance, 0f, 0f));
        Gizmos.DrawRay(ledgeCheckHorizontal.position, new Vector3(collisionSensesData.wallCheckDistance, 0f, 0f));
        Gizmos.DrawRay(ledgeCheckVertical.position, new Vector3(0f, -WallCheckDistance, 0f));
    }

    #region Check Properties

    public bool Grounded => Physics2D.OverlapCircle(groundCheck.position, collisionSensesData.groundCheckRadius, collisionSensesData.whatIsGround);
    public bool WallFront => Physics2D.Raycast(wallCheck.position, Vector2.right * core.Movement.FacingDirection, collisionSensesData.wallCheckDistance, collisionSensesData.whatIsGround);
    public bool WallBack => Physics2D.Raycast(wallCheck.position, Vector2.right * -core.Movement.FacingDirection, collisionSensesData.wallCheckDistance, collisionSensesData.whatIsGround);
    public bool LedgeHorizontal => Physics2D.Raycast(ledgeCheckHorizontal.position, Vector2.right * core.Movement.FacingDirection, collisionSensesData.wallCheckDistance, collisionSensesData.whatIsGround);
    public bool LedgeVertical => Physics2D.Raycast(ledgeCheckVertical.position, Vector2.down, WallCheckDistance, WhatIsGround);
    public bool Ceiling => Physics2D.OverlapCircle(ceilingCheck.position, collisionSensesData.groundCheckRadius, collisionSensesData.whatIsGround);

    #endregion
}
