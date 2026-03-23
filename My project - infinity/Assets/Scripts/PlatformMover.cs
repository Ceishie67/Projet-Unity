using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    private float speed;
    private float despawnX;

    /// <summary>
    /// Initialise la plateforme avec sa vitesse et la position de despawn.
    /// </summary>
    public void Initialize(float platformSpeed, float despawnPositionX)
    {
        speed = platformSpeed;
        despawnX = despawnPositionX;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < despawnX)
            Destroy(gameObject);
    }
}
