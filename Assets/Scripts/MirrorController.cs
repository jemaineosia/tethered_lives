using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MirrorController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform playerTransform;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (playerTransform == null)
            Debug.LogWarning("MirrorController: PlayerTransform not assigned.");
    }

    void Update()
    {
        if (playerTransform == null) return;

        float input = Input.GetAxisRaw("Horizontal"); // get same input
        float inverted = -input;                      // invert it
        Vector2 velocity = rb.linearVelocity;
        velocity.x = inverted * moveSpeed;
        rb.linearVelocity = velocity;
    }
}
