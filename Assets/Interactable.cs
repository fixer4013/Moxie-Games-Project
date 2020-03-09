using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public Animator anim;
    public Text text;
    public GameObject door;

    public GameObject player;
    public Camera cam;
    public GameObject keyholeCamera;

    public bool listening;
    public bool peeking;
    public float timer;
    public bool isInteracting;

    Vector3 playerPosition;
    Quaternion playerRotation;
    Quaternion cameraRotation;

    Vector3 playerInteractionPosition;
    Quaternion playerInteractionRotationLeft;
    Quaternion playerInteractionRotationRight;
    Quaternion playerInteractionRotationForward;
    Quaternion camInteractionRotation;

    float playerPositionSpeed;
    float playerRotationSpeedLeft;
    float playerRotationSpeedRight;
    float playerRotationSpeedForward;
    float camRotationSpeed;

    void Update()
    {
        if (LookAtInteractable.currentObject != door || isInteracting)
        {
            text.enabled = false;
        }
        else
        {
            text.enabled = true;
        }

        if (peeking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(StopPeeking());
            }
        }

        if (listening)
        {
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(StopListening());
            }
        }



    }

    public void DoorOpenAnimation()
    {
        anim.Play("DoorOpen");
        text.enabled = false;
        door.tag = "Untagged";
        Destroy(this);
        return;
    }

    public IEnumerator DoorListening()
    {
        isInteracting = true;

        playerPosition = player.transform.localPosition;
        playerRotation = player.transform.localRotation;
        cameraRotation = cam.transform.localRotation;

        playerInteractionPosition = door.transform.position + new Vector3(0, -0.3f, -0.5f);
        playerInteractionRotationLeft = Quaternion.Euler(0, -90, 0);
        playerInteractionRotationRight = Quaternion.Euler(0, 90, 0);
        camInteractionRotation = Quaternion.identity;

        playerPositionSpeed = Mathf.Abs(Vector3.Distance(player.transform.localPosition, playerInteractionPosition) / timer);
        playerRotationSpeedLeft = Mathf.Abs((player.transform.localRotation.eulerAngles.y - 270) / timer);
        playerRotationSpeedRight = Mathf.Abs((player.transform.localRotation.eulerAngles.y - 90) / timer);
        if (cameraRotation.eulerAngles.x > 180)
        {
            camRotationSpeed = Mathf.Abs((cameraRotation.eulerAngles.x - 360) / timer);
        }
        else
        {
            camRotationSpeed = Mathf.Abs(cameraRotation.eulerAngles.x / timer);
        }

        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<LookAtInteractable>().enabled = false;
        cam.GetComponent<DimensionCamera>().enabled = false;


        for (float i = 0; i < timer; i += Time.deltaTime)
        {
            player.transform.localPosition = Vector3.MoveTowards(player.transform.localPosition, playerInteractionPosition, playerPositionSpeed * Time.deltaTime);
            if (player.transform.rotation.eulerAngles.y > 180)
            {
                player.transform.localRotation = Quaternion.RotateTowards(player.transform.localRotation, playerInteractionRotationLeft, playerRotationSpeedLeft * Time.deltaTime);

            }
            else
            {
                player.transform.localRotation = Quaternion.RotateTowards(player.transform.localRotation, playerInteractionRotationRight, playerRotationSpeedRight * Time.deltaTime);
            }
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, camInteractionRotation, camRotationSpeed * Time.deltaTime);

            yield return 0;
        }

        listening = true;
    }

    IEnumerator StopListening()
    {
        listening = false;

        for (float i = 0; i < timer; i += Time.deltaTime)
        {
            player.transform.localPosition = Vector3.MoveTowards(player.transform.localPosition, playerPosition, playerPositionSpeed * Time.deltaTime);
            if (player.transform.rotation.eulerAngles.y > 180)
            {
                player.transform.localRotation = Quaternion.RotateTowards(player.transform.localRotation, playerRotation, playerRotationSpeedLeft * Time.deltaTime);
            }
            else
            {
                player.transform.localRotation = Quaternion.RotateTowards(player.transform.localRotation, playerRotation, playerRotationSpeedRight * Time.deltaTime);
            }
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, cameraRotation, camRotationSpeed * Time.deltaTime);

            yield return 0;
        }

        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<LookAtInteractable>().enabled = true;
        cam.GetComponent<DimensionCamera>().enabled = true;

        isInteracting = false;
    }

    public IEnumerator Peek()
    {
        isInteracting = true;

        playerPosition = player.transform.localPosition;
        playerRotation = player.transform.localRotation;
        cameraRotation = cam.transform.localRotation;

        playerInteractionPosition = door.transform.position + new Vector3(-0.6f, -1f, -0.5f);
        playerInteractionRotationForward = Quaternion.identity;
        camInteractionRotation = Quaternion.identity;

        playerPositionSpeed = Mathf.Abs(Vector3.Distance(player.transform.localPosition, playerInteractionPosition) / timer);

        if (player.transform.localRotation.eulerAngles.y > 180)
        {
            playerRotationSpeedForward = Mathf.Abs((player.transform.localRotation.eulerAngles.y - 360) / timer);
        }
        else
        {
            playerRotationSpeedForward = Mathf.Abs((player.transform.localRotation.eulerAngles.y) / timer);
        }

        if (cameraRotation.eulerAngles.x > 180)
        {
            camRotationSpeed = Mathf.Abs((cameraRotation.eulerAngles.x - 360) / timer);
        }
        else
        {
            camRotationSpeed = Mathf.Abs(cameraRotation.eulerAngles.x / timer);
        }

        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<LookAtInteractable>().enabled = false;
        cam.GetComponent<DimensionCamera>().enabled = false;


        for (float i = 0; i < timer; i += Time.deltaTime)
        {
            player.transform.localPosition = Vector3.MoveTowards(player.transform.localPosition, playerInteractionPosition, playerPositionSpeed * Time.deltaTime);
            player.transform.localRotation = Quaternion.RotateTowards(player.transform.localRotation, playerInteractionRotationForward, playerRotationSpeedForward * Time.deltaTime);
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, camInteractionRotation, camRotationSpeed * Time.deltaTime);

            yield return 0;
        }

        cam.gameObject.SetActive(false);
        keyholeCamera.SetActive(true);
        peeking = true;
    }

    IEnumerator StopPeeking()
    {
        peeking = false;
        cam.gameObject.SetActive(true);
        keyholeCamera.SetActive(false);

        for (float i = 0; i < timer; i += Time.deltaTime)
        {
            player.transform.localPosition = Vector3.MoveTowards(player.transform.localPosition, playerPosition, playerPositionSpeed * Time.deltaTime);
            player.transform.localRotation = Quaternion.RotateTowards(player.transform.localRotation, playerRotation, playerRotationSpeedForward * Time.deltaTime);
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, cameraRotation, camRotationSpeed * Time.deltaTime);

            yield return 0;
        }

        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<LookAtInteractable>().enabled = true;
        cam.GetComponent<DimensionCamera>().enabled = true;

        isInteracting = false;
    }
}