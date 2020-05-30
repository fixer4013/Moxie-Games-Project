using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LookAtInteractable : MonoBehaviour
{
    float maxDistance = 2;

    public static GameObject currentObject;

    public Camera cam;

    public LayerMask layerInteractables;

    public TextMeshProUGUI doorTxt;
    public TextMeshProUGUI keyTxt;

    void Update()
    {
        LookAt();
        if (currentObject != null)
        {
            Interact();
            if (currentObject.GetComponent<ActualDoor>())
            {
                doorTxt.enabled = true;
                if (currentObject.GetComponent<ActualDoor>().doorMechanics.isInteracting)
                {
                    doorTxt.enabled = false;
                }
            }
            if (currentObject.GetComponent<KeyPickUp>())
            {
                keyTxt.enabled = true;
            }
        }
        if (currentObject == null)
        {
            doorTxt.enabled = false;
            if (keyTxt != null)
            {
                keyTxt.enabled = false;
            }
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
            if (currentObject.GetComponent<ActualDoor>())
            {
                if (currentObject.GetComponent<ActualDoor>().doorMechanics.open || currentObject.GetComponent<ActualDoor>().doorMechanics.doorAnimating)
                {
                    currentObject = null;
                }
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
            if (currentObject.GetComponent<ActualDoor>())
            {
                StartCoroutine(currentObject.GetComponent<ActualDoor>().doorMechanics.DoorOpenAnimation(1, false));
            }
            if (currentObject.GetComponent<GoToSleep>())
            {
                StartCoroutine(currentObject.GetComponent<GoToSleep>().Sleep());
            }
            if (currentObject.GetComponent<KeyPickUp>())
            {
                currentObject.GetComponent<KeyPickUp>().OpenDoor();
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentObject.GetComponent<ActualDoor>())
            {
                currentObject.GetComponent<ActualDoor>().doorMechanics.Knocking();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentObject.GetComponent<ActualDoor>())
            {
                if (currentObject.GetComponent<ActualDoor>().doorMechanics.side1.isPlayerNear)
                {
                    StartCoroutine(currentObject.GetComponent<ActualDoor>().doorMechanics.PeekingSide1());
                }
                if (currentObject.GetComponent<ActualDoor>().doorMechanics.side2.isPlayerNear)
                {
                    StartCoroutine(currentObject.GetComponent<ActualDoor>().doorMechanics.PeekingSide2());
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (currentObject.GetComponent<ActualDoor>())
            {
                if (currentObject.GetComponent<ActualDoor>().doorMechanics.side1.isPlayerNear)
                {
                    StartCoroutine(currentObject.GetComponent<ActualDoor>().doorMechanics.ListeningSide1());
                }
                if (currentObject.GetComponent<ActualDoor>().doorMechanics.side2.isPlayerNear)
                {
                    StartCoroutine(currentObject.GetComponent<ActualDoor>().doorMechanics.ListeningSide2());
                }
            }
        }
    }
}
