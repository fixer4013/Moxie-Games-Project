using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIOpenDoors : MonoBehaviour
{
    public LayerMask doorsMiddleLayer;
    public float openDoorsRadius;

    // Update is called once per frame
    void Update()
    {
        var test = Physics.OverlapSphere(transform.position, openDoorsRadius, doorsMiddleLayer);

        if (test.Length != 0)
        {
            test[0].gameObject.GetComponent<PhysicalDoor>().ndm.enemyIsNear = true;
        }
    }
}
