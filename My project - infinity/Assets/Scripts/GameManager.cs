using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private HUDManager hudManager;

    private int score;
    private bool isGameOver;

    public int Score => score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    /// <summary>
    /// Incrémente le score et met à jour l'UI.
    /// </summary>
    public void AddScore(int amount)
    {
        if (isGameOver) return;
        score += amount;
        hudManager.UpdateScore(score);
    }

    /// <summary>
    /// Déclenche la fin de la partie.
    /// </summary>
    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Debug.Log("Game Over !");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
