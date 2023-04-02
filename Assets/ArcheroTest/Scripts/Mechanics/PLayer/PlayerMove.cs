using SimpleInputNamespace;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Joystick Joystick;
    public GameObject Target;
    public bool Stay;

    private Vector3 _direction;
    [SerializeField]private PlayerConfig _playerConfig;


    private void FixedUpdate()
    {
        Vector3 InputVector = new Vector3(Joystick.xAxis.value, 0, Joystick.yAxis.value);
        InputVector *= _playerConfig.MoveSpeed;
        Rigidbody.velocity = InputVector;

        _direction = new Vector3(InputVector.x, 0, InputVector.z);
        if (InputVector != Vector3.zero)
        {
            Stay = false;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction), _playerConfig.RotateLerpSpeed * Time.deltaTime);
        }
        else if (Target)
        {
            Stay = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position), _playerConfig.RotateLerpSpeed * Time.deltaTime);
        }

    }
}
