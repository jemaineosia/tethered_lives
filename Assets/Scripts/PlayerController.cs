using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    private static readonly Logger logger = new Logger(Debug.unityLogger.logHandler);

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        logger.logEnabled = true;
    }

    void Update()
    {
        HandleMovement();

        if(Input.GetButtonDown("Jump"))
            logger.Log(LogType.Log, "isGrounded: " + isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            PerformJump();
        }
    }

    void FixedUpdate()
    {
        CheckGroundStatus();
    }

    /// <summary>
    /// Handles horizontal movement input and applies velocity.
    /// </summary>
    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    /// <summary>
    /// Applies an upward velocity for jumping.
    /// </summary>
    void PerformJump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    /// <summary>
    /// Checks if the player is grounded by overlap test.
    /// </summary>
    void CheckGroundStatus()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("MovingPlatform"))
            StartCoroutine(SetParentNextFrame(col.collider.transform));
    }

    System.Collections.IEnumerator SetParentNextFrame(Transform newParent)
    {
        yield return null; // Wait one frame
        if (newParent != null && newParent.gameObject.activeInHierarchy)
            transform.SetParent(newParent);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.CompareTag("MovingPlatform") && transform.parent != null)
        {
            // Only unparent if the player is still active in the hierarchy
            if (gameObject.activeInHierarchy)
                transform.SetParent(null);
        }
    }

}
