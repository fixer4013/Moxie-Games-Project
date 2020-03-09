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

    public bool listening;
    public float timer;
    public bool isInteracting;

    Vector3 playerPosition;
    Quaternion playerRotation;
    Quaternion cameraRotation;

    Vector3 playerListenPosition;
    Quaternion playerListenRotationLeft;
    Quaternion playerListenRotationRight;
    Quaternion camListenRotation;

    float playerPositionSpeed;
    float playerRotationSpeedLeft;
    float playerRotationSpeedRight;
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

        playerListenPosition = door.transform.position + new Vector3(0, -0.3f, -0.5f);
        playerListenRotationLeft = Quaternion.Euler(0, -90, 0);
        playerListenRotationRight = Quaternion.Euler(0, 90, 0);
        camListenRotation = Quaternion.identity;

        playerPositionSpeed = Mathf.Abs(Vector3.Distance(player.transform.localPosition, playerListenPosition) / timer);
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
            player.transform.localPosition = Vector3.MoveTowards(player.transform.localPosition, playerListenPosition, playerPositionSpeed * Time.deltaTime);
            if (player.transform.rotation.eulerAngles.y > 180)
            {
                player.transform.localRotation = Quaternion.RotateTowards(player.transform.localRotation, playerListenRotationLeft, playerRotationSpeedLeft * Time.deltaTime);

            }
            else
            {
                player.transform.localRotation = Quaternion.RotateTowards(player.transform.localRotation, playerListenRotationRight, playerRotationSpeedRight * Time.deltaTime);
            }
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, camListenRotation, camRotationSpeed * Time.deltaTime);

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
}