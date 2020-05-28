using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsVariables : MonoBehaviour
{
    public static float generalMouseSensitivity;
    public Slider mouseSensitivitySlider;
    public GameObject optionMenu;

    // Start is called before the first frame update
    void Start()
    {
        generalMouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity");
        mouseSensitivitySlider.value = generalMouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        if (optionMenu.activeSelf == true)
        {
            generalMouseSensitivity = mouseSensitivitySlider.value;
            PlayerPrefs.SetFloat("mouseSensitivity", generalMouseSensitivity);
        }
    }

    public void MouseSensitivityAdd()
    {
        if (mouseSensitivitySlider.maxValue > generalMouseSensitivity + (mouseSensitivitySlider.maxValue - mouseSensitivitySlider.minValue) / 10)
        {
            mouseSensitivitySlider.value += (mouseSensitivitySlider.maxValue - mouseSensitivitySlider.minValue) / 10;
        }
        else
        {
            mouseSensitivitySlider.value = mouseSensitivitySlider.maxValue;
        }
    }
    public void MouseSensitivitySubtract()
    {
        if (mouseSensitivitySlider.minValue < generalMouseSensitivity - (mouseSensitivitySlider.maxValue - mouseSensitivitySlider.minValue) / 10)
        {
            mouseSensitivitySlider.value -= (mouseSensitivitySlider.maxValue - mouseSensitivitySlider.minValue) / 10;
        }
        else
        {
            mouseSensitivitySlider.value = mouseSensitivitySlider.minValue;
        }
    }
}
