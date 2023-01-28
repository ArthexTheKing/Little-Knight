using UnityEngine;

public class CollisionSenses : CoreComponent
{
    #region Check Transform

    public Transform GroundCheck => GenericNotImplementedError<Transform>.TryGet(groundCheck, core.transform.parent.name);
    public Transform WallCheck => GenericNotImplementedError<Transform>.TryGet(wallCheck, core.transform.parent.name);
    public Transform LedgeCheckHorizontal => GenericNotImplementedError<Transform>.TryGet(ledgeCheckHorizontal, core.transform.parent.name);
    public Transform LedgeCheckVertical => GenericNotImplementedError<Transform>.TryGet(ledgeCheckVertical, core.transform.parent.name);
    public Transform CeilingCheck => GenericNotImplementedError<Transform>.TryGet(ceilingCheck, core.transform.parent.name);
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheckHorizontal;
    [SerializeField] private Transform ledgeCheckVertical;
    [SerializeField] private Transform ceilingCheck;

    #endregion

    #region Data

    public float GroundCheckRadius { get => collisionSensesData.groundCheckRadius; }
    public float WallCheckDistance { get => collisionSensesData.wallCheckDistance; }
    public LayerMask WhatIsGround { get => collisionSensesData.whatIsGround; }

    [SerializeField] private SO_CollisionSensesData collisionSensesData;

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(groundCheck.position, GroundCheckRadius);
        //Gizmos.DrawWireSphere(ceilingCheck.position, GroundCheckRadius);
        //Gizmos.DrawRay(wallCheck.position, new Vector3(WallCheckDistance, 0f, 0f));
        //Gizmos.DrawRay(wallCheck.position, new Vector3(-WallCheckDistance, 0f, 0f));
        //Gizmos.DrawRay(ledgeCheckHorizontal.position, new Vector3(WallCheckDistance, 0f, 0f));
        //Gizmos.DrawRay(ledgeCheckVertical.position, new Vector3(0f, -WallCheckDistance, 0f));
    }

    #region Check Properties

    public bool Grounded => Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
    public bool WallFront => Physics2D.Raycast(WallCheck.position, Vector2.right * core.Movement.FacingDirection, WallCheckDistance, WhatIsGround);
    public bool WallBack => Physics2D.Raycast(WallCheck.position, Vector2.right * -core.Movement.FacingDirection, WallCheckDistance, WhatIsGround);
    public bool LedgeHorizontal => Physics2D.Raycast(LedgeCheckHorizontal.position, Vector2.right * core.Movement.FacingDirection, WallCheckDistance, WhatIsGround);
    public bool LedgeVertical => Physics2D.Raycast(LedgeCheckVertical.position, Vector2.down, WallCheckDistance, WhatIsGround);
    public bool Ceiling => Physics2D.OverlapCircle(CeilingCheck.position, GroundCheckRadius, WhatIsGround);

    #endregion
}
