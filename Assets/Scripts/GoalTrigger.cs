using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Goal reached! Loading next chapter.");
            LevelManager.Instance.LoadNextChapter();
        }
    }

}
