using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Joystick Joystick;

    [Range(0f, 1f)]
    public float RotationLerpSpeed = 1;

    public float MoveSpeed = 1;

    private Vector3 _direction;
    public GameObject Target;

    private void FixedUpdate()
    {
        Vector3 InputVector = new Vector3(Joystick.xAxis.value, 0, Joystick.yAxis.value);
        InputVector *= MoveSpeed;
        Rigidbody.velocity = InputVector;

        _direction = new Vector3(InputVector.x, 0, InputVector.z);
        if (InputVector != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction), RotationLerpSpeed);
        }
        else if (Target)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position), RotationLerpSpeed);
        }

    }
}
