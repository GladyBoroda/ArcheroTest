using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public GameObject EffectOnHit;

    private PlayerMove TargetPosition;
    private EnemyConfig _enemyConfig;
    private EnemyBullet _enemyBullet;
    private Vector3 _direction;

    private void Start()
    {
        _direction = (TargetPosition.transform.position - transform.position).normalized;
    }
    public void Construct(EnemyConfig playerConfig, PlayerMove playerMove, EnemyBullet enemyBullet)
    {
        TargetPosition = playerMove;
        _enemyConfig = playerConfig;
        _enemyBullet = enemyBullet;
    }

    private void Update()
    {
        Rigidbody.velocity = _direction * _enemyConfig.AttackSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            TargetPosition.OnHit();
        }
        Instantiate(EffectOnHit, transform.position, Quaternion.identity);

        if (!collision.gameObject.GetComponent<Bullet>())
        {
            Destroy(gameObject);
        }

    }
}