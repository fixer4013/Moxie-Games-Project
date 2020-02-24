using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentHotel : MonoBehaviour
{
    int currentDimension;
    public bool dimensionSwitchEnabled = true;

    public Transform hotel1;
    public Transform hotel2;
    public Transform player;
    public CharacterController controller;

    void Start()
    {
        currentDimension = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentDimension != 1 && dimensionSwitchEnabled == true)
        {
            StartCoroutine(DimensionSwitch(currentDimension));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currentDimension != 2 && dimensionSwitchEnabled == true)
        {
            StartCoroutine(DimensionSwitch(currentDimension));
        }
    }

    IEnumerator DimensionSwitch(int currentHotel)
    {
        dimensionSwitchEnabled = false;
        controller.enabled = false;
        if (currentHotel == 1)
        {
            player.position = player.position - hotel1.position + hotel2.position;
            currentDimension = 2;
        }
        if (currentHotel == 2)
        {
            player.position = player.position - hotel2.position + hotel1.position;
            currentDimension = 1;
        }
        controller.enabled = true;
        yield return new WaitForSeconds(1f);
        dimensionSwitchEnabled = true;
    }
}
