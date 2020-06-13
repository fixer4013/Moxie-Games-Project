using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnockingCTrigger : MonoBehaviour
{
    public GameStates gs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            gs.GameState2_2();
        }
    }
}
