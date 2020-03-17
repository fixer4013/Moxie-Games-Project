using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtInteractable : MonoBehaviour
{
    float maxDistance = 2;

    public static GameObject currentObject;

    public Camera cam;

    public LayerMask layerInteractables;

    void Update()
    {
        LookAt();
        if (currentObject != null)
        {
            Interact();
        }
    }

    void LookAt()
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

    }

    void Interact()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentObject.tag == "Door")
            {
                StartCoroutine(currentObject.transform.parent.GetComponent<Interactable>().Peek());
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (currentObject.tag == "Door")
            {
                StartCoroutine(currentObject.transform.parent.GetComponent<Interactable>().DoorListening());
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentObject.transform.parent.GetComponent<Interactable>())
            {
                currentObject.transform.parent.GetComponent<Interactable>().DoorOpenAnimation();
            }
        }
    }
}
