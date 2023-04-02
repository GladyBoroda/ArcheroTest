using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    private bool _isSpawned = false;


    private void Update()
    {
        if (!_isSpawned)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        foreach (var item in enemies)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(item, spawnPosition, Quaternion.identity);
        }
        _isSpawned = true;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float spawnX = Random.Range(-5, 5);
        float spawnY = Random.Range(12, -5);
        Vector3 spawnPosition = new Vector3(spawnX, 0.5f, spawnY);

        while (Physics.Raycast( spawnPosition, Vector3.up, 1))
        {
            spawnX = Random.Range(-5, 5);
            spawnY = Random.Range(12, -5);
            spawnPosition = new Vector3(spawnX, 0.5f, spawnY);
        }
        



        return spawnPosition;
    }
}
