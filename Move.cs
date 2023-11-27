using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;

    // LayerMask to specify what layers count as ground
    public LayerMask groundLayers;
    // The transform component used to check if the player is grounded
    public Transform groundCheck;
    // The radius to check for ground
    public float groundCheckRadius = 0.2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump input received"); // Debug line to check for jump input
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // Move the player
        float move = Input.GetAxis("Horizontal"); // Get the input from arrow keys
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
    }
}
