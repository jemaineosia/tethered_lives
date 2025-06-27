using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(BoxCollider2D))]
public class LightZone : MonoBehaviour
{
    public float radius = 3f;
    public LayerMask platformLayer;
    private Light2D spotlight; // assuming URP 2D Lights
    void Awake()
    {
        spotlight = GetComponentInChildren<Light2D>();
        spotlight.pointLightOuterRadius = radius;
        spotlight.enabled = false;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // enable light
            spotlight.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spotlight.enabled = false;
        }
    }
}
