using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtInteractable : MonoBehaviour
{
    float maxDistance = 2;

    public static GameObject currentObject;

    public Camera cam;

    public LayerMask layerInteractables;

    public Text txt;

    void Update()
    {
        LookAt();
        if (currentObject != null)
        {
            Interact();
            txt.enabled = true;
        }
        else
        {
            txt.enabled = false;
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
            if (currentObject.GetComponent<PhysicalDoor>().ndm.open || currentObject.GetComponent<PhysicalDoor>().ndm.doorAnimating)
            {
                currentObject = null;
            }
        }
        else
        {
            currentObject = null;
        }

    }

    void Interact()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentObject.GetComponent<PhysicalDoor>())
            {
                StartCoroutine(currentObject.GetComponent<PhysicalDoor>().ndm.DoorOpenAnimation(1f, false));
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentObject.GetComponent<PhysicalDoor>())
            {
                currentObject.GetComponent<PhysicalDoor>().ndm.Knocking();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentObject.GetComponent<PhysicalDoor>())
            {
                if (currentObject.GetComponent<PhysicalDoor>().ndm.side1.isPlayerNear)
                {
                    StartCoroutine(currentObject.GetComponent<PhysicalDoor>().ndm.PeekingSide1());
                }
                if (currentObject.GetComponent<PhysicalDoor>().ndm.side2.isPlayerNear)
                {
                    StartCoroutine(currentObject.GetComponent<PhysicalDoor>().ndm.PeekingSide2());
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (currentObject.GetComponent<PhysicalDoor>())
            {
                if (currentObject.GetComponent<PhysicalDoor>().ndm.side1.isPlayerNear)
                {
                    StartCoroutine(currentObject.GetComponent<PhysicalDoor>().ndm.ListeningSide1());
                }
                if (currentObject.GetComponent<PhysicalDoor>().ndm.side2.isPlayerNear)
                {
                    StartCoroutine(currentObject.GetComponent<PhysicalDoor>().ndm.ListeningSide2());
                }
            }
        }
    }
}
