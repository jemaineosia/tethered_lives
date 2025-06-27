using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI narrativeText;
    public float fadeDuration = 0.5f, displayTime = 2f;

    void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("UIManager instance created.");
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Debug.Log("UIManager instance already exists. Destroying duplicate.");
            Destroy(gameObject);
        }
    }

    public void ShowText(string message)
    {
        Debug.Log("ShowText called with: " + message);
        StopAllCoroutines();
        StartCoroutine(DoShow(message));
    }

    IEnumerator DoShow(string msg)
    {
        if (narrativeText == null || this == null)
            yield break;

        narrativeText.text = msg;
        // fade in
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            narrativeText.alpha = t / fadeDuration;
        }
        narrativeText.alpha = 1;
        yield return new WaitForSeconds(displayTime);
        // fade out
        for (float t = fadeDuration; t > 0; t -= Time.deltaTime)
        {
            narrativeText.alpha = t / fadeDuration;
        }
        narrativeText.alpha = 0;
    }
}
