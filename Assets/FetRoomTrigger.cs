using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetRoomTrigger : MonoBehaviour
{
    public GameStates gs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            gs.GameState4();
            this.gameObject.SetActive(false);
        }
    }
}
