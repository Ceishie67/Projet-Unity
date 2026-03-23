using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    /// <summary>
    /// Lance la scène de jeu.
    /// </summary>
 public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }
    /// <summary>
    /// Quitte le jeu.
    /// </summary>
    public void OnQuit()
    {
        Application.Quit();
    }
}
