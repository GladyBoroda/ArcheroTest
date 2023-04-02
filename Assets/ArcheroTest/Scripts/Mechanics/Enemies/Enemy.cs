using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public PlayerMove Player;
    public NavMeshAgent Agent;

    private void Update()
    {
        Vector3 DirectionToPlayer = Player.transform.position - transform.position;
        Ray ray = new Ray(transform.position, DirectionToPlayer);
        Physics.Raycast(ray, out RaycastHit hit);

        if (!hit.rigidbody)
        {
            Agent.isStopped = false;
            Agent.SetDestination(Player.transform.position);
        }
        else
        {
            Agent.isStopped = true;
        }


    }


}
