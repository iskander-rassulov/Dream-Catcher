using UnityEngine;

public class DreamGenerator : MonoBehaviour
{
    public GameObject dreamPrefab;   // The prefab of the ball to generate
    public float spawnInterval = 5f;    // The interval between ball spawns
    public float minSpawnX = -5f;   // The minimum X position for ball spawning
    public float maxSpawnX = 5f;    // The maximum X position for ball spawning
    public float dreamSpeed = 5f;    // The speed at which the ball moves along the Z axis

    private float timeSinceLastSpawn = 0f;    // The time since the last ball spawn

    void Update()
    {
        // Update the time since the last ball spawn
        timeSinceLastSpawn += Time.deltaTime;
        
        // If the spawn interval has passed, spawn a ball
        if (timeSinceLastSpawn >= spawnInterval)
        {
            Debug.Log(timeSinceLastSpawn);
            Debug.Log("Object CREATED");
            // Reset the time since the last ball spawn
            timeSinceLastSpawn = 0f;

            // Generate a random X position for the ball
            float spawnX = Random.Range(minSpawnX, maxSpawnX);

            // Spawn the ball at the random X position and at the same Y and Z positions as the generator
            GameObject newDream = Instantiate(dreamPrefab, new Vector3(spawnX, transform.position.y, transform.position.z), Quaternion.identity);

            // Make the ball move only along the Z axis
            Rigidbody dreamRigidbody = newDream.GetComponent<Rigidbody>();
            dreamRigidbody.velocity = Vector3.back * dreamSpeed;
        }
    }
}
