using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    Light lampLight;
    bool flickeringOn = true;

    float timer;

    void Start()
    {
        lampLight = GetComponent<Light>();

        timer = Random.Range(0.3f, 0.8f);
    }

    private void Update()
    {
        FlickeringLight();
    }

    void FlickeringLight()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            lampLight.enabled = !lampLight.enabled;
            timer = Random.Range(0.15f, 0.8f);
        }
    }
}
