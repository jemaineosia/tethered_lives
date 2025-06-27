using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SinkPlatform : MonoBehaviour
{
    [Header("Sink Settings")]
    public float sinkDepth = 0.5f;
    public float sinkTime = 1f;
    public float respawnDelay = 2f;

    private Vector3 _startPos;
    private BoxCollider2D _col;

    void Awake()
    {
        _startPos = transform.position;
        _col = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            StartCoroutine(SinkAndReset());
    }

    IEnumerator SinkAndReset()
    {
        // sink down
        float t = 0;
        Vector3 endPos = _startPos - Vector3.up * sinkDepth;
        while (t < sinkTime)
        {
            transform.position = Vector3.Lerp(_startPos, endPos, t / sinkTime);
            t += Time.deltaTime;
            yield return null;
        }
        transform.position = endPos;
        _col.enabled = false;

        // wait then reset
        yield return new WaitForSeconds(respawnDelay);
        transform.position = _startPos;
        _col.enabled = true;
    }
}
