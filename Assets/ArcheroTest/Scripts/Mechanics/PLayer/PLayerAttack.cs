using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerAttack : MonoBehaviour
{
    public Enemy Enemy;
    public Bullet BulletPrefabs;
    public Transform SpawnPosition;
    public PlayerMove PlayerMove;

    [SerializeField] private PlayerConfig _playerConfig;
    private float Timer;

    private void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            Timer = 1;

            if (PlayerMove.Stay)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        var bullet = Instantiate(BulletPrefabs, SpawnPosition.position, Quaternion.identity);
        bullet.TargetPosition = Enemy.transform.position;

    }
}
