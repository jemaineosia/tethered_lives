using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SwitchPlatform : MonoBehaviour
{
    [HideInInspector] public bool isPressed;
    public Sprite upSprite, downSprite;  // optional: for visual feedback
    private SpriteRenderer _sr;
    private BoxCollider2D _col;

    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _col = GetComponent<BoxCollider2D>();
        _col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isPressed && other.CompareTag("Player"))
        {
            isPressed = true;
            if (downSprite != null) _sr.sprite = downSprite;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (isPressed && other.CompareTag("Player"))
        {
            isPressed = false;
            if (upSprite != null) _sr.sprite = upSprite;
        }
    }
}
