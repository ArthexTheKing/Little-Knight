using UnityEngine;

public class CollisionSenses : CoreComponent
{
    public Transform GroundCheck
    {
        get
        {
            if (groundCheck) return groundCheck;
            Debug.LogError("No Ground Check on " + core.transform.parent.name);
            return null;
        }
    }
    public Transform WallCheck
    {
        get
        {
            if (wallCheck) return wallCheck;
            Debug.LogError("No Wall Check on " + core.transform.parent.name);
            return null;
        }
    }
    public Transform LedgeCheckHorizontal
    {
        get
        {
            if (ledgeCheckHorizontal) return ledgeCheckHorizontal;
            Debug.LogError("No Ledge Check Horizontal on " + core.transform.parent.name);
            return null;
        }
    }
    public Transform LedgeCheckVertical
    {
        get
        {
            if (ledgeCheckVertical) return ledgeCheckVertical;
            Debug.LogError("No Ledge Check Vertical on " + core.transform.parent.name);
            return null;
        }
    }
    public Transform CeilingCheck
    {
        get
        {
            if (ceilingCheck) return ceilingCheck;
            Debug.LogError("No Ceiling Check on " + core.transform.parent.name);
            return null;
        }
    }

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
