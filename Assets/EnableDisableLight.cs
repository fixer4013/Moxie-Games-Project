using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableLight : MonoBehaviour
{
    public float distance;
    public GameObject player;
    Light lightComp;

    private void Start()
    {
        lightComp = GetComponent<Light>();
    }

    private void Update()
    {
        if (lightComp.enabled == true)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > distance +10)
            {
                lightComp.enabled = false;
            }
        }
        if (lightComp.enabled == false)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= distance + 10)
            {
                lightComp.enabled = true;
            }
        }

    }
}
