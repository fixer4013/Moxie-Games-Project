using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public Animator anim;
    public AudioSource elevatorSounds;
    public AudioClip elevatorCloseSound;

    private void OnTriggerEnter(Collider other)
    {
        anim.Play("ElevatorDoorsIntroClose");
        elevatorSounds.clip = elevatorCloseSound;
        elevatorSounds.spatialBlend = 1;
        elevatorSounds.Play();
        this.gameObject.SetActive(false);
    }
}
