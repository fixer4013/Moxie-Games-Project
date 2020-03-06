using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtInteractable : MonoBehaviour
{
    float maxDistance = 2;

    public static GameObject currentObject;

    public Camera cam;

    public LayerMask layerInteractables;

    void FixedUpdate()
    {

        // Will contain the information of which object the raycast hit
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // if raycast hits, it checks if it hit an object with the tag Player
        if (Physics.Raycast(ray, out hit, maxDistance, layerInteractables))

        {
            currentObject = hit.transform.gameObject;
        }
        else
        {
            currentObject = null;
        }
        Debug.Log(currentObject);
    }
}
