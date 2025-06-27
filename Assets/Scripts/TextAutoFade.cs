using System.Collections;
using TMPro;
using UnityEngine;

public class TextAutoFade : MonoBehaviour
{
    public float delayBeforeFade = 2f;
    public float fadeDuration = 1f;

    private TextMeshProUGUI text;
    private Color originalColor;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        originalColor = text.color;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(delayBeforeFade);

        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}
