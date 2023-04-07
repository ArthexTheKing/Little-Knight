using UnityEngine;

public class CollisionSenses : CoreComponent
{
    private Movement movement;
    private Movement Movement => core.GetCoreComponent(ref movement);

    [field: SerializeField] public Transform GroundCheck { get; private set; }
    [field: SerializeField] public Transform WallCheck { get; private set; }
    [field: SerializeField] public Transform LedgeCheckHorizontal { get; private set; }
    [field: SerializeField] public Transform LedgeCheckVertical { get; private set; }
    [field: SerializeField] public Transform CeilingCheck { get; private set; }

    [field: SerializeField] public float GroundCheckRadius { get; private set; }
    [field: SerializeField] public float WallCheckDistance { get; private set; }
    [field: SerializeField] public LayerMask WhatIsGround { get; private set; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if(GroundCheck) {
            Gizmos.DrawWireSphere(GroundCheck.position, GroundCheckRadius);
        }

        if(WallCheck) {
            Gizmos.DrawRay(WallCheck.position, new Vector3(WallCheckDistance, 0f, 0f));
            Gizmos.DrawRay(WallCheck.position, new Vector3(-WallCheckDistance, 0f, 0f));
        }

        if(LedgeCheckHorizontal) {
            Gizmos.DrawRay(LedgeCheckHorizontal.position, new Vector3(WallCheckDistance, 0f, 0f));
        }

        if(LedgeCheckVertical) {
            Gizmos.DrawRay(LedgeCheckVertical.position, new Vector3(0f, -WallCheckDistance, 0f));
        }

        if(CeilingCheck) {
            Gizmos.DrawWireSphere(CeilingCheck.position, GroundCheckRadius);
        }

    }

    public bool Grounded => Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
    public bool WallFront => Physics2D.Raycast(WallCheck.position, Vector2.right * Movement.FacingDirection, WallCheckDistance, WhatIsGround);
    public bool WallBack => Physics2D.Raycast(WallCheck.position, Vector2.right * -Movement.FacingDirection, WallCheckDistance, WhatIsGround);
    public bool LedgeHorizontal => Physics2D.Raycast(LedgeCheckHorizontal.position, Vector2.right * Movement.FacingDirection, WallCheckDistance, WhatIsGround);
    public bool LedgeVertical => Physics2D.Raycast(LedgeCheckVertical.position, Vector2.down, WallCheckDistance, WhatIsGround);
    public bool Ceiling => Physics2D.OverlapCircle(CeilingCheck.position, GroundCheckRadius, WhatIsGround);

}
