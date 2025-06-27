using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SpringPad : MonoBehaviour
{
    [Header("Bounce Settings")]
    public float bounceForce = 12f;
    public AudioClip springSound;        // optional

    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.playOnAwake = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Player")) return;

        var rb = other.collider.GetComponent<Rigidbody2D>();
        // Preserve horizontal velocity
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);

        if (springSound != null)
            _audioSource.PlayOneShot(springSound);
    }
}
