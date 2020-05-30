using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKnockingSoundHelper : MonoBehaviour
{
    public EventKnockingSound help;
    public Transform player;
    bool isTriggered;

    private void Update()
    {
        if (!isTriggered)
        {
            if (Vector3.Distance(player.position, transform.position) < 8)
            {
                StartCoroutine(help.AppearEnemy());
                isTriggered = true;
            }
        }
    }
}
