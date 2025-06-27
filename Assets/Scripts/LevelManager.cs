using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Logger))]
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    private static readonly Logger logger = new Logger(Debug.unityLogger.logHandler);

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Loads the next scene in Build Settings order. Logs if at last scene.
    /// </summary>
    public void LoadNextChapter()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex >= SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene("EndingScene");
        else
            SceneManager.LoadScene(nextIndex);

    }

    public void LoadChapter(int chapterIndex)
    {
        if (chapterIndex < 0 || chapterIndex >= SceneManager.sceneCountInBuildSettings)
        {
            logger.Log(LogType.Error, $"Invalid chapter index: {chapterIndex}. Cannot load scene.");
            return;
        }
        logger.Log(LogType.Log, $"Loading chapter at index: {chapterIndex}.");
        SceneManager.LoadScene(chapterIndex);
    }

    /// <summary>
    /// Restarts (reloads) the current scene.
    /// </summary>
    public void RestartChapter()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        logger.Log(LogType.Log, $"Restarting current chapter: index {currentIndex}.");
        SceneManager.LoadScene(currentIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        Debug.Log("Application.Quit() called. (Editor mode: window not closed)");
#else
        Application.Quit();
#endif
    }
}
