using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	public Transform[] spawnPoints;

	public GameObject blockPrefab;

	private int timeBetweenWaves = 3;

	private float timeToSpawn = 1f;

	void Update () {
        
        if (Time.timeSinceLevelLoad >= timeToSpawn)
		{
			SpawnBlocks();
			timeToSpawn = Time.timeSinceLevelLoad + timeBetweenWaves;
        }

	}

	void SpawnBlocks ()
	{
		int randomIndex = Random.Range(0, spawnPoints.Length);

		for (int i = 0; i < spawnPoints.Length; i++)
		{
			if (randomIndex != i)
			{
                GameObject blocks = (GameObject)Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
                blocks.transform.SetParent(gameObject.transform.parent);
            }
		}
	}
	
}
