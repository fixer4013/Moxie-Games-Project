using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongRoom : MonoBehaviour
{
    public AIMaze ai;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            ai.agent.SetDestination(collider.transform.position);
        }
    }
}
