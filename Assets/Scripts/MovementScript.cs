using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce = 10f;
    public float moveSpeed = 5f;
    public float wallJumpForce = 10f;

    private bool isGrounded = true;
    private bool isTouchingWall = false;
    private bool isFacingRight = true;

    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public Transform groundCheck;
    public Transform wallCheck;
    public float checkRadius = 0.2f;

    void Update()
    {
        HandleMovement();
        HandleJump();
        FlipCharacter();
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (moveInput * moveSpeed, rb.velocity.y);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(Vector2.up);
        }
        else if (isTouchingWall)
        {
            Vector2 wallJumpDirection = isFacingRight ? Vector2.left : Vector2.right;
            Jump(Vector2.up + wallJumpDirection);
        }
    }

    void Jump(Vector2 direction)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(direction.normalized * jumpForce, ForceMode2D.Impulse);
    }

    void FlipCharacter()
    {
        if (rb.velocity.x > 0 && !isFacingRight || rb.velocity.x < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(isFacingRight ? 1 : -1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, checkRadius, wallLayer);
    }
}
