using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public DoorMechanics door;

    public void OpenDoor()
    {
        door.locked = false;
        gameObject.SetActive(false);
    }
}
