using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{   
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float moveInput;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ReadInput();
    }
    void FixedUpdate()
    {
        Move();   
    }
    private void ReadInput()
    {
        Keyboard kb = Keyboard.current;
        moveInput = 0f;

        if (kb.aKey.isPressed) moveInput = -1f;
        if (kb.dKey.isPressed) moveInput = 1f;
    }
    private void Move()
    {
        rb.linearVelocityX = moveInput * moveSpeed;
    }
}
