using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    public float lightStrength;
    Light lampLight;
    bool flickeringOn = true;

    void Start()
    {
        lampLight = GetComponent<Light>();
        lightStrength = lampLight.intensity;

        if (flickeringOn == true)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        while (true)
        {
            float rand3 = Random.Range(0, 20);
            float rand2;
            if (rand3 >= 19)
            {
                rand2 = Random.Range(16, 20);
            }
            else
            {
                rand2 = Random.Range(16, 18);
            }
            float rand = Random.Range(0, rand2);
            if (rand >= 16)
            {
                lampLight.intensity = 0f;
            }
            else
            {
                lampLight.intensity = lightStrength;
            }
            yield return new WaitForSeconds(Random.Range(0.05f, 0.15f));
        }
    }
}
