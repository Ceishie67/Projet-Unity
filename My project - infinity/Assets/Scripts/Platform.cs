using UnityEngine;

public class Platform : MonoBehaviour
{
    private bool hasScored;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (hasScored || player == null) return;

        // Incrémente le score quand la plateforme dépasse le joueur
        if (transform.position.x < player.position.x)
        {
            hasScored = true;
            GameManager.Instance.AddScore(1);
        }
    }
}
