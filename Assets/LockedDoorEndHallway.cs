using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorEndHallway : MonoBehaviour
{
    public DoorMechanics dm;
    public int amountOfEventsToBeDone = 3;

    void Start()
    {
        
    }

    void Update()
    {
        if (amountOfEventsToBeDone == 0)
        {
            UnlockDoor();
            amountOfEventsToBeDone = -1;
        }
    }

    void UnlockDoor()
    {
        dm.locked = false;
    }
}
