using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    public float amplitude = 2f;    // how far from the start position
    public float frequency = 1f;    // how fast it moves
    public bool horizontal = true;  // true = left/right, false = up/down

    private Vector3 startPos;

    void Awake()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * frequency) * amplitude;
        if (horizontal)
            transform.position = startPos + Vector3.right * offset;
        else
            transform.position = startPos + Vector3.up * offset;
    }
}
