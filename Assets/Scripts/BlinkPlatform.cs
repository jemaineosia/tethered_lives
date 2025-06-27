using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BlinkPlatform : MonoBehaviour
{
    [Header("Blink Settings")]
    public float onDuration = 1f;
    public float offDuration = 1f;

    private BoxCollider2D _col;
    private SpriteRenderer _sr;

    void Awake()
    {
        _col = GetComponent<BoxCollider2D>();
        _sr = GetComponent<SpriteRenderer>();
        StartCoroutine(BlinkRoutine());
    }

    IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // Platform active
            _col.enabled = true;
            if (_sr != null) _sr.enabled = true;
            yield return new WaitForSeconds(onDuration);

            // Platform inactive
            _col.enabled = false;
            if (_sr != null) _sr.enabled = false;
            yield return new WaitForSeconds(offDuration);
        }
    }
}
