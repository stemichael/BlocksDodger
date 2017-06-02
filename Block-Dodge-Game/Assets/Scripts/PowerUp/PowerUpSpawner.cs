using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    public Transform[] spawnPoints;

    public GameObject[] powerUpPrefabs;

    private int timeBetweenDrops = 0;

    private float timeToSpawn = 0;

    void Start()
    {
        timeBetweenDrops = Random.Range(15, 30);
        timeToSpawn = Random.Range(7.0f, 10.0f);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToSpawn)
        {
            SpawnBlocks();

            timeBetweenDrops = Random.Range(15, 30);

            timeToSpawn = Time.timeSinceLevelLoad + timeBetweenDrops;
        }

    }

    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        int randomPowerUp = Random.Range(0, powerUpPrefabs.Length); ;

        GameObject powerUp = (GameObject)Instantiate(powerUpPrefabs[randomPowerUp], spawnPoints[randomIndex].position, Quaternion.identity);
        powerUp.transform.parent = gameObject.transform.parent;
    }
}
