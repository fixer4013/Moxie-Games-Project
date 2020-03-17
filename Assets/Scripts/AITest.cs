using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITest : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 target;
    public float goalDistance = 40f;

    private void Update()
    {
        agent.SetDestination(target);
    }
}
