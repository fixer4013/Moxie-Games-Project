using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class IncreaseVignette : MonoBehaviour
{
    public PostProcessVolume volume;
    public Vignette vignette;
    bool increase;
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            increase = true;
        }
        if (increase)
        {
            vignette.intensity.value += Time.deltaTime * 0.2f;
        }
    }
}
