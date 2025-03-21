using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform respawnPoint;

    private Rigidbody2D rb;
    private bool canJump = false;
    private bool moveLeft = false;
    private bool moveRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move left or right
        float moveInput = 0f;
        if (moveLeft) moveInput = -1f;
        if (moveRight) moveInput = 1f;

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Respawn if player falls
        if (transform.position.y < -20)
        {
            Respawn();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }

    public void MoveLeft(bool state) { moveLeft = state; }
    public void MoveRight(bool state) { moveRight = state; }

    public void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void Respawn()
    {
        transform.position = respawnPoint.position;
        rb.velocity = Vector2.zero;
    }
}
