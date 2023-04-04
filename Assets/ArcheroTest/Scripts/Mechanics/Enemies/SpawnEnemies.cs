using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<Enemy> Enemies = new List<Enemy>();

    [HideInInspector]
    public List<Enemy> EnemiesOnLevel = new List<Enemy>();
    public PlayerMove Player;
    public EnemyConfig EnemyConfig;
    public EnemyBullet EnemyBullet;

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

        foreach (var item in Enemies)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            var enemy = Instantiate(item, spawnPosition, Quaternion.identity);
            enemy.Construct(Player, EnemyConfig, EnemyBullet, this);
            EnemiesOnLevel.Add(enemy);
        }
        _isSpawned = true;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float spawnX = Random.Range(-5, 5);
        float spawnY = Random.Range(12, -5);
        Vector3 spawnPosition = new Vector3(spawnX, 0.5f, spawnY);

        while (Physics.Raycast(spawnPosition, Vector3.up, 1))
        {
            spawnX = Random.Range(-5, 5);
            spawnY = Random.Range(12, -5);
            spawnPosition = new Vector3(spawnX, 0.5f, spawnY);
        }
        return spawnPosition;
    }
}
