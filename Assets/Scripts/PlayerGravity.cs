using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public Transform playerTransform;
    public DimensionCamera playerCamera;
    public string gravityDirection = "Down";

    void Update()
    {
        bool gravityDown = Input.GetKeyDown(KeyCode.Alpha5);
        bool gravityUp = Input.GetKeyDown(KeyCode.Alpha6);
        bool gravityLeft = Input.GetKeyDown(KeyCode.Alpha7);
        bool gravityRight = Input.GetKeyDown(KeyCode.Alpha8);
        bool gravityBackward = Input.GetKeyDown(KeyCode.Alpha9);
        bool gravityForward = Input.GetKeyDown(KeyCode.Alpha0);

        if (gravityDown)
        {
            playerTransform.GetComponent<DimensionCharacters>().gravityVelocity = Vector3.zero;

            switch (gravityDirection)
            {
                case "Down":
                    gravityDirection = "Down"; //nothing
                    break;
                case "Up":
                    playerTransform.rotation = Quaternion.Euler(0, playerTransform.eulerAngles.y, 0);
                    if (playerCamera.transform.eulerAngles.x > 180)
                    {
                        playerCamera.xRotation = -playerCamera.transform.eulerAngles.x + 360;
                    }
                    else
                    {
                        playerCamera.xRotation = -playerCamera.transform.eulerAngles.x;
                    }
                    gravityDirection = "Down";
                    break;
                case "Left":
                    playerTransform.rotation = Quaternion.Euler(0, playerTransform.eulerAngles.y, 0);
                    gravityDirection = "Down";
                    break;
                case "Right":
                    playerTransform.rotation = Quaternion.Euler(0, playerTransform.eulerAngles.y, 0);
                    gravityDirection = "Down";
                    break;
                case "Backward":
                    gravityDirection = "Down";
                    break;
                case "Forward":
                    gravityDirection = "Down";
                    break;
            }
        }

        if (gravityUp)
        {
            playerTransform.GetComponent<DimensionCharacters>().gravityVelocity = Vector3.zero;

            switch (gravityDirection)
            {
                case "Down":
                    playerTransform.rotation = Quaternion.Euler(0, playerTransform.eulerAngles.y, 180);
                    if (playerCamera.transform.eulerAngles.x > 180)
                    {
                        playerCamera.xRotation = playerCamera.transform.eulerAngles.x + 360;
                    }
                    else
                    {
                        playerCamera.xRotation = playerCamera.transform.eulerAngles.x;
                    }
                    gravityDirection = "Up";
                    break;
                case "Up":
                    gravityDirection = "Up"; //nothing
                    break;
                case "Left":
                    playerTransform.rotation = Quaternion.Euler(0, playerTransform.eulerAngles.y, 180);
                    gravityDirection = "Up";
                    break;
                case "Right":
                    playerTransform.rotation = Quaternion.Euler(0, playerTransform.eulerAngles.y, 180);
                    gravityDirection = "Up";
                    break;
                case "Backward":
                    gravityDirection = "Up";
                    break;
                case "Forward":
                    gravityDirection = "Up";
                    break;
            }
        }

        if (gravityLeft)
        {
            playerTransform.GetComponent<DimensionCharacters>().gravityVelocity = Vector3.zero;

            switch (gravityDirection)
            {
                case "Down":
                    playerTransform.rotation = Quaternion.Euler(playerTransform.eulerAngles.y, 0, -90);
                    gravityDirection = "Left";
                    break;
                case "Up":
                    playerTransform.rotation = Quaternion.Euler(playerTransform.eulerAngles.y, 0, -90);
                    gravityDirection = "Left";
                    break;
                case "Left":
                    gravityDirection = "Left"; //nothing
                    break;
                case "Right":
                    playerTransform.rotation = Quaternion.Euler(playerTransform.eulerAngles.y, 0, -90);
                    gravityDirection = "Left";
                    break;
                case "Backward":
                    gravityDirection = "Left";
                    break;
                case "Forward":
                    gravityDirection = "Left";
                    break;
            }
        }

        if (gravityRight)
        {
            playerTransform.GetComponent<DimensionCharacters>().gravityVelocity = Vector3.zero;

            switch (gravityDirection)
            {
                case "Down":
                    playerTransform.rotation = Quaternion.Euler(playerTransform.eulerAngles.y, 0, 90);
                    gravityDirection = "Right";
                    break;
                case "Up":
                    playerTransform.rotation = Quaternion.Euler(playerTransform.eulerAngles.y, 0, 90);
                    gravityDirection = "Right";
                    break;
                case "Left":
                    playerTransform.rotation = Quaternion.Euler(playerTransform.eulerAngles.y, 0, 90);
                    gravityDirection = "Right";
                    break;
                case "Right":
                    gravityDirection = "Right"; //nothing
                    break;
                case "Backward":
                    gravityDirection = "Right";
                    break;
                case "Forward":
                    gravityDirection = "Right";
                    break;
            }
        }

        if (gravityBackward)
        {
            playerTransform.GetComponent<DimensionCharacters>().gravityVelocity = Vector3.zero;

            switch (gravityDirection)
            {
                case "Down":
                    playerTransform.rotation = Quaternion.Euler(playerTransform.eulerAngles.y, 0, 90);
                    gravityDirection = "Backward";
                    break;
                case "Up":
                    playerTransform.rotation = Quaternion.Euler(playerTransform.eulerAngles.y, 0, 90);
                    gravityDirection = "Backward";
                    break;
                case "Left":
                    playerTransform.rotation = Quaternion.Euler(playerTransform.eulerAngles.y, 0, 90);
                    gravityDirection = "Backward";
                    break;
                case "Right":
                    gravityDirection = "Backward";
                    break;
                case "Backward":
                    gravityDirection = "Backward"; //nothing
                    break;
                case "Forward":
                    gravityDirection = "Backward";
                    break;
            }
        }

    }

}
