using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("Chapter1");
    }

    public void OnQuitButtonPressed()
    {
#if UNITY_EDITOR
        Debug.Log("Application.Quit() called. (Editor mode: window not closed)");
#else
        Application.Quit();
#endif
    }
}
