using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeHallway2 : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player.position.z <= -36f)
        {
            transform.localScale = new Vector3(1, 1, 1 + (-player.position.z - 36)/6);
            transform.position = new Vector3(50, 0, -72 - (-player.position.z - 36) * 4);
        }
        if (player.position.z > -36f)
        {
            transform.localScale = Vector3.one;
            transform.position = new Vector3(50, 0, -72);
        }
    }
}
