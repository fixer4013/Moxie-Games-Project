using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rooms : MonoBehaviour
{
    public AudioSource audioS;
    public Light ceilingLight;
    public int roomCondition; //1=good //2=bad //more added later

    public AIMaze ai;
    public NavMeshAgent nav;

    private void OnTriggerEnter(Collider other)
    {
        if (roomCondition == 2)
        {
            if (other.gameObject.tag == "Player")
            {
                ai.maxSpeed += .5f;
                if (nav.speed != 0)
                {
                    nav.speed = ai.maxSpeed;
                }
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (roomCondition == 2)
        {
            if (other.gameObject.tag == "Player")
            {
                nav.SetDestination(other.transform.position);
            }
        }
    }
}
