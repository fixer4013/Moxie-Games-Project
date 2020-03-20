using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSide : MonoBehaviour
{
    public bool isPlayerNear;
    public Camera cam;
    public Transform PeekingTransform;
    public Transform ListeningTransformLeft;
    public Transform ListeningTransformRight;
    public GameObject roomOnTheOtherSide;
    public AudioSource roomAudio;

    void Awake()
    {
        roomAudio = roomOnTheOtherSide.GetComponent<Rooms>().audioS;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerNear = false;
        }
    }
}
