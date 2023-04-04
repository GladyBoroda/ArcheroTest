using TMPro;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public enum EnemyType
{
    Range,
    Melee
}

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public EnemyType EnemyType;
    public LayerMask WallLayer;
    public int Health = 4;
    public Transform SpawnBullet;
    public GameObject CoinPrefab;

    [SerializeField] private bool canShot;
    private PlayerMove _player;
    private EnemyConfig _enemyConfig;
    private EnemyBullet _enemyBulletPrefab;
    private SpawnEnemies _spawnEnemies;
    private float Timer;

    public void Construct(PlayerMove player, EnemyConfig enemyConfig, EnemyBullet enemyBullet, SpawnEnemies spawnEnemies)
    {
        _player = player;
        _enemyConfig = enemyConfig;
        _enemyBulletPrefab = enemyBullet;
        _spawnEnemies = spawnEnemies;
    }

    public void OnHit()
    {
        Health -= _player._playerConfig.Damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        Vector3 directionOnPlayer = _player.transform.position - transform.position ;
        transform.rotation = Quaternion.LookRotation(directionOnPlayer);

        if (EnemyType == EnemyType.Range)
        {
            Vector3 DirectionToPlayer = _player.transform.position - transform.position;
            Ray ray = new(transform.position, DirectionToPlayer);

            if (Physics.Raycast(ray, out RaycastHit hit, _enemyConfig.ShootingRange, WallLayer))
            {
                Agent.isStopped = false;
                Agent.SetDestination(_player.transform.position);
            }
            else
            {
                Agent.isStopped = true;

                if (Timer > 0)
                {
                    Timer -= Time.deltaTime;
                }
                else
                {
                    AttackRange();
                }
            }

            if (Health <= 0)
            {
                Die();
            }
        }

        if (EnemyType == EnemyType.Melee)
        {
            Agent.SetDestination(_player.transform.position);
            Agent.speed = _enemyConfig.MoveSpeed;

            if ((transform.position - _player.transform.position).sqrMagnitude < 2.1f)
            {
                AttackMelee();
            }
        }
    }

    private void AttackMelee()
    {
        _player.PlayerHealth -= _enemyConfig.Damage;
        //Debug.Log("Attack");
    }

    private void AttackRange()
    {
        Timer = _enemyConfig.ShootingPeriod;
        var bullet = Instantiate(_enemyBulletPrefab, SpawnBullet.position, Quaternion.identity);
        bullet.Construct(_enemyConfig, _player, _enemyBulletPrefab);
    }

    private void Die()
    {
        Instantiate(CoinPrefab,transform.position,transform.rotation);
        Destroy(gameObject);
        _spawnEnemies.EnemiesOnLevel.Remove(this);
    }

}
