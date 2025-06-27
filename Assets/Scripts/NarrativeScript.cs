using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class NarrativeTrigger : MonoBehaviour
{
    public string message;
    public TextMeshProUGUI narrativeText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            narrativeText.text = message;
        }
    }
}
