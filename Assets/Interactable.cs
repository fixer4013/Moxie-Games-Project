using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public GameObject door;
    public Text text;

    private void Update()
    {
        if (LookAtInteractable.currentObject == door)
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }
}