
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 1;
    public GameObject EffectBulletOnHit;

    private Vector3 TargetPosition;
    private Enemy _target;
    private PlayerConfig _playerConfig;

    public void Construct(Enemy target, PlayerConfig playerConfig)
    {
        _target = target;
        TargetPosition = target.transform.position;
        _playerConfig = playerConfig;
        Debug.Log(TargetPosition);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Time.deltaTime * _playerConfig.AttackSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(EffectBulletOnHit, transform.position, Quaternion.identity);
        if (collision.gameObject.GetComponent<Enemy>())
        {
            _target.OnHit();
        }
        if (!collision.gameObject.GetComponent<EnemyBullet>() && !collision.gameObject.GetComponent<PlayerMove>())
        {
            Destroy(gameObject);
        }
    }
}
