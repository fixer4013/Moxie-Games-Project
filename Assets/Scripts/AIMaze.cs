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

    private void Start()
    {
        ChooseTarget();
    }

    private void Update()
    {
        if (!agent.hasPath && choosePath == false)
        {
            choosePath = true;
            Invoke("ChooseTarget", 2f);
        }
    }

    void ChooseTarget()
    {
        choosePath = false;
        currentTarget = targets[Random.Range(0, targets.Length - 1)];
        agent.SetDestination(currentTarget.transform.position);

    }
}
