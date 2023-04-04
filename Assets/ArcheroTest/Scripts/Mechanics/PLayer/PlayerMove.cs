using SimpleInputNamespace;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Joystick Joystick;
    public EnemiesDetector EnemiesDetector;
    public bool Stay;
    public int PlayerHealth = 5;
    public PlayerConfig _playerConfig;

    private Enemy Enemy;
    private Vector3 _direction;
    [SerializeField] private EnemyConfig _enemyConfig;

    public void OnHit()
    {
        PlayerHealth -= _enemyConfig.Damage;

        if (PlayerHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("You Die!");
    }

    private void FixedUpdate()
    {
        EnemiesDetector.CheckEnemyOnLevel(out Enemy);

        Vector3 InputVector = new Vector3(Joystick.xAxis.value, 0, Joystick.yAxis.value);
        InputVector *= _playerConfig.MoveSpeed;
        Rigidbody.velocity = InputVector;

        _direction = new Vector3(InputVector.x, 0, InputVector.z);
        if (InputVector != Vector3.zero)
        {
            Stay = false;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction), _playerConfig.RotateLerpSpeed * Time.deltaTime);
        }
        else if (Enemy)
        {
            Stay = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Enemy.transform.position - transform.position), _playerConfig.RotateLerpSpeed * Time.deltaTime);
        }

    }
}
