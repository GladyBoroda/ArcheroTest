
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 1;

    public Vector3 TargetPosition;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Time.deltaTime * Speed);
    }
}
