using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{   
    public float moveSpeed = 5f;
    public float climbSpeed = 3f;
    public LayerMask ladderLayer;
    public float ladderCheckRadius = 0.5f;
    public Collider2D ladderCollider;

    private float verticalInput;
    public bool isClimbing;
    private Rigidbody2D rb;
    private float moveInput;
    private float defaultGravityScale;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravityScale = rb.gravityScale;
    }
    void Update()
    {
        ReadInput();
    }
    void FixedUpdate()
    {
        Move();   
        HandleLadder();
    }
    private void ReadInput()
    {
        Keyboard kb = Keyboard.current;
        moveInput = 0f;

        if (kb.aKey.isPressed) moveInput = -1f;
        if (kb.dKey.isPressed) moveInput = 1f;

        verticalInput = 0f;
        if (kb.wKey.isPressed) verticalInput = 1f;
        if (kb.sKey.isPressed) verticalInput = -1f;
    }
    private void Move()
    {
        rb.linearVelocityX = moveInput * moveSpeed;
    }
    private bool IsOnLadder()
    {
        return Physics2D.OverlapCircle(transform.position, ladderCheckRadius, ladderLayer);
    }
    private void HandleLadder()
    {
        bool onLadder = IsOnLadder();
        if (verticalInput == 0) ladderCollider.isTrigger = false;
        if (onLadder && verticalInput != 0f) isClimbing = true;
        if (!onLadder)
        {
            rb.gravityScale = defaultGravityScale;
            isClimbing = false;
            return;
        }
        if (isClimbing)
        {   
            ladderCollider.isTrigger = true;
            rb.gravityScale = 0f;
            rb.linearVelocityY = verticalInput * climbSpeed;
        }
        else
        {
            rb.gravityScale = defaultGravityScale;
        }
    }
}
