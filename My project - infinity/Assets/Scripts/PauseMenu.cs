using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private bool isPaused;
    private InputAction pauseAction;

    private void Awake()
    {
        pauseAction = new InputAction("Pause", InputActionType.Button);
        pauseAction.AddBinding("<Keyboard>/escape");
        pauseAction.Enable();
    }

    private void OnDestroy()
    {
        pauseAction.Disable();
    }

    private void Update()
    {
        if (pauseAction.WasPressedThisFrame())
            TogglePause();
    }

    /// <summary>
    /// Bascule entre pause et jeu.
    /// </summary>
    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    /// <summary>
    /// Retourne au menu principal.
    /// </summary>
    public void OnQuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
