using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRoom4 : MonoBehaviour
{
    public GameStates gs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            gs.GameState3();
            this.gameObject.SetActive(false);
        }
    }
}
