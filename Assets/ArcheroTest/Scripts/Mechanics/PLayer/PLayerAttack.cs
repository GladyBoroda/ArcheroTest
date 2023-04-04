using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Enemy Enemy;
    public Bullet BulletPrefabs;
    public Transform SpawnPosition;
    public PlayerMove PlayerMove;

    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private EnemiesDetector _enemyDetector;
    private float Timer;

    private void Update()
    {

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if (PlayerMove.Stay)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        if (_enemyDetector.CheckEnemyOnLevel(out var enemy))
        {
            Timer = _playerConfig.PeriodAttack;
            var bullet = Instantiate(BulletPrefabs, SpawnPosition.position, Quaternion.identity);
            bullet.Construct(enemy,_playerConfig);
            bullet.transform.LookAt(enemy.transform.position);
            Debug.Log(enemy.name);
        }
    }
}
