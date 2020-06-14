using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LookAtInteractable : MonoBehaviour
{
    float maxDistance = 2;

    public static GameObject currentObject;

    public Camera cam;

    public LayerMask layerInteractables;

    public Image interactIcon;
    public Image peekIcon;
    public Image listeningIcon;
    public TextMeshProUGUI keyTxt;

    void Update()
    {
        LookAt();
        if (currentObject != null)
        {
            interactIcon.color = new Color(255, 255, 255, 1f);
            Interact();
            if (currentObject.GetComponent<ActualDoor>())
            {
                var dm = currentObject.GetComponent<ActualDoor>().doorMechanics;
                if (dm.openable)
                {
                    interactIcon.color = new Color(255, 255, 255, 1f);
                }
                else
                {
                    interactIcon.color = new Color(255, 255, 255, .2f);
                }
                if (dm.peekable)
                {
                    peekIcon.color = new Color(255, 255, 255, 1f);
                }
                else
                {
                    peekIcon.color = new Color(255, 255, 255, .2f);
                }
                if (dm.listenable)
                {
                    listeningIcon.color = new Color(255, 255, 255, 1f);
                }
                else
                {
                    listeningIcon.color = new Color(255, 255, 255, .2f);
                }
                if (currentObject.GetComponent<ActualDoor>().doorMechanics.isInteracting)
                {
                    interactIcon.enabled = false;
                    peekIcon.enabled = false;
                    listeningIcon.enabled = false;
                }
                else
                {
                    interactIcon.enabled = true;
                    peekIcon.enabled = true;
                    listeningIcon.enabled = true;
                }
            }
            if (currentObject.GetComponent<KeyPickUp>())
            {
                keyTxt.enabled = true;
            }
            
        }
        if (currentObject == null)
        {
            interactIcon.color = new Color(255, 255, 255, .2f);
            peekIcon.color = new Color(255, 255, 255, .2f);
            listeningIcon.color = new Color(255, 255, 255, .2f);
            if (keyTxt != null)
            {
                keyTxt.enabled = false;
            }
            interactIcon.color = new Color(255, 255, 255, .2f);
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
                if (currentObject.GetComponent<ActualDoor>().doorMechanics.openable)
                {
                    StartCoroutine(currentObject.GetComponent<ActualDoor>().doorMechanics.DoorOpenAnimation(2, false));
                }
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

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    if (currentObject.GetComponent<ActualDoor>())
        //    {
        //        if (currentObject.GetComponent<ActualDoor>().doorMechanics.knockable)
        //        {
        //            currentObject.GetComponent<ActualDoor>().doorMechanics.Knocking();
        //        }
        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            if (currentObject.GetComponent<ActualDoor>())
            {
                if (currentObject.GetComponent<ActualDoor>().doorMechanics.peekable)
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
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (currentObject.GetComponent<ActualDoor>())
            {
                if (currentObject.GetComponent<ActualDoor>().doorMechanics.listenable)
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
}
