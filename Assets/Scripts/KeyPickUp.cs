using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPickUp : MonoBehaviour
{
    public DoorMechanics door;
    public int roomNumber;
    public AudioSource audioTrigger;
    public TextMeshProUGUI tmp;
    public GameObject pickedUpKeyUI;
    public TextMeshProUGUI pickedUpKeyUItmp;

    private void Update()
    {
        if (door.locked == false)
        {
            if (audioTrigger.isPlaying)
            {
                pickedUpKeyUI.SetActive(false);
            }
        }
    }

    public void OpenDoor()
    {
        door.locked = false;
        gameObject.transform.position = Vector3.zero;
        pickedUpKeyUI.SetActive(true);
        pickedUpKeyUItmp.text = "Room " + roomNumber;
        GameStates.state += 1;
        StartCoroutine(PickedUpKey());
    }

    IEnumerator PickedUpKey()
    {
        tmp.text = "You found a key to room " + roomNumber;
        tmp.GetComponent<Animator>().Play("InstructionsFadeIn");
        yield return new WaitForSeconds(5);
        tmp.GetComponent<Animator>().Play("InstructionsFadeOut");
    }
}
