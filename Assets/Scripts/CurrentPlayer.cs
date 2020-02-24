using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    public GameObject currentPlayer;

    float currentPlayerRotation;
    Vector3 currentPlayerVelocity;
    float currentCameraRotation;
    Vector3 currentPlayerPosition;

    private void Awake()
    {
        player1.GetComponent<Dimension>().player.SetActive(true);
        player2.GetComponent<Dimension>().player.SetActive(false);
        player3.GetComponent<Dimension>().player.SetActive(false);

        currentPlayer = player1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentPlayer != player1)
        {
            DimensionSwitch(player1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currentPlayer != player2)
        {
            DimensionSwitch(player2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && currentPlayer != player3)
        {
            DimensionSwitch(player3);
        }
    }

    void DimensionSwitch(GameObject newDimension)
    {
        //get all the variables from current dimension
        currentPlayerPosition = currentPlayer.GetComponent<Dimension>().player.transform.position - currentPlayer.transform.position;
        currentPlayerRotation = currentPlayer.GetComponent<Dimension>().player.transform.rotation.eulerAngles.y;
        currentCameraRotation = currentPlayer.GetComponent<Dimension>().cameraRotation.rotation.eulerAngles.x;
        if (currentPlayer != player3)
        {
            currentPlayerVelocity = currentPlayer.GetComponent<Dimension>().player.GetComponent<CharacterController>().velocity;
        }

        //change current player to another one
        currentPlayer.GetComponent<Dimension>().player.SetActive(false);
        currentPlayer = newDimension;
        currentPlayer.GetComponent<Dimension>().player.SetActive(true);

        //set variables of the new dimension
        currentPlayer.GetComponent<Dimension>().player.transform.position = currentPlayerPosition + currentPlayer.transform.position;
        currentPlayer.GetComponent<Dimension>().player.transform.rotation = Quaternion.Euler(0f, currentPlayerRotation, 0f);
        if (currentPlayer != player3)
        {
            currentPlayer.GetComponent<Dimension>().player.GetComponent<DimensionCharacters>().gravityVelocity = currentPlayerVelocity;
        }
        else
        {
            currentPlayer.GetComponent<Dimension>().player.GetComponent<DimensionCharacters>().gravityVelocity = Vector3.zero;
        }

        if (currentCameraRotation > 180)
        {
            currentPlayer.GetComponent<Dimension>().cameraRotation.GetComponent<DimensionCamera>().xRotation = -360 + currentCameraRotation;
        }
        else
        {
            currentPlayer.GetComponent<Dimension>().cameraRotation.GetComponent<DimensionCamera>().xRotation = currentCameraRotation;
        }

    }
}
