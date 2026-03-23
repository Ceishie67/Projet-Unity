using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Platform Settings")]
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 2f;
    [SerializeField] private float spawnX = 12f;
    [SerializeField] private float despawnX = -12f;
    [SerializeField] private float spaceBetweenPlatforms = 4f;

    [Header("Speed Settings")]
    [SerializeField] private float initialSpeed = 3f;
    [SerializeField] private float speedIncrement = 0.1f;
    [SerializeField] private float maxSpeed = 10f;

    private float currentSpeed;
    private float timer;
    private float spawnInterval;

    private void Start()
    {
        currentSpeed = initialSpeed;
        UpdateSpawnInterval();
        SpawnPlatform();
    }

    private void Update()
    {
        IncreaseSpeed();

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnPlatform();
        }
    }

    /// <summary>
    /// Fait apparaître une plateforme à une hauteur aléatoire.
    /// </summary>
    private void SpawnPlatform()
    {
        float randomY = Random.Range(minHeight, maxHeight);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0f);

        GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        platform.GetComponent<PlatformMover>().Initialize(currentSpeed, despawnX);
    }

    /// <summary>
    /// Augmente progressivement la vitesse des plateformes.
    /// </summary>
    private void IncreaseSpeed()
    {
        currentSpeed = Mathf.Min(currentSpeed + speedIncrement * Time.deltaTime, maxSpeed);
        UpdateSpawnInterval();
    }

    private void UpdateSpawnInterval()
    {
        spawnInterval = spaceBetweenPlatforms / currentSpeed;
    }
}
