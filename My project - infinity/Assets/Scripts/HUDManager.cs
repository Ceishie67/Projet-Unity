using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    /// <summary>
    /// Met à jour l'affichage du score.
    /// </summary>
    public void UpdateScore(int score)
    {
        scoreText.text = $"Score : {score}";
    }
}
