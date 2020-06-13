using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDoorC : MonoBehaviour
{
    public GameStates gs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            StartCoroutine(gs.GameState2_1());
            this.gameObject.SetActive(false);
        }
    }
}
