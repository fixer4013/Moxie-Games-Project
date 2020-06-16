using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOpenDoorTest : MonoBehaviour
{
    public DoorMechanics dm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            StartCoroutine(dm.DoorOpenAnimation(0.33f, false));
            this.gameObject.SetActive(false);
        }
    }
}
