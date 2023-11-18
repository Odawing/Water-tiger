using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellfishSpawner : MonoBehaviour
{
    public float spawnInterval;

    private float lastSpawnTime;

    [SerializeField]
    private GameObject shellfishPref;
    [SerializeField]
    private List<Transform> shellfishSpawners;

    private void FixedUpdate()
    {
        if (Time.time > spawnInterval + lastSpawnTime)
        {
            lastSpawnTime = Time.time;
            SpawnShellfish();
        }
    }

    private void SpawnShellfish()
    {
        int shellsToSpawn = Random.Range(1, 4);
        var spawners = new List<Transform>(shellfishSpawners);

        for (int i = 0; i < shellsToSpawn; i++)
        {
            var spawnIndex = Random.Range(0, spawners.Count);
            var spawnTr = spawners[spawnIndex];
            spawners.RemoveAt(spawnIndex);

            Instantiate(shellfishPref, spawnTr.position, Quaternion.identity);
        }
    }
}