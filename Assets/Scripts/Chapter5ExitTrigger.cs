using UnityEngine;

public class Chapter5ExitTrigger : MonoBehaviour
{
    public GameObject bluePlayer;
    public GameObject pinkPlayer;

    private bool blueEntered = false;
    private bool pinkEntered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == bluePlayer)
        {
            blueEntered = true;
            Debug.Log("Blue player entered exit trigger.");
        }
        else if (other.gameObject == pinkPlayer)
        {
            pinkEntered = true;
            Debug.Log("Pink player entered exit trigger.");
        }

        if (blueEntered && pinkEntered)
        {
            Debug.Log("Both players entered! Loading next chapter.");
            LevelManager.Instance.LoadNextChapter();
            // Optionally, disable this trigger to prevent multiple calls
            enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == bluePlayer)
            blueEntered = false;
        else if (other.gameObject == pinkPlayer)
            pinkEntered = false;
    }
}
