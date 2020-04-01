using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMaze : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform[] targets;
    Transform currentTarget;
    bool choosePath;
    public float maxSpeed;

    public PlayerMovement player;

    private void Start()
    {
        maxSpeed = agent.speed;
        ChooseTarget();
    }

    private void Update()
    {
        if (!agent.hasPath && choosePath == false)
        {
            choosePath = true;
            Invoke("ChooseTarget", 2f);
        }

        if (RoomNumber.roomNumberEnemy == RoomNumber.roomnumberPlayer)
        {
            if (player.x != 0 || player.z != 0)
            {
                agent.SetDestination(player.transform.position);
                agent.speed = maxSpeed * 2;
            }
        }
    }

    void ChooseTarget()
    {
        choosePath = false;
        int rand = Random.Range(0, targets.Length);
        currentTarget = targets[rand];
        agent.SetDestination(currentTarget.transform.position);

    }
}
