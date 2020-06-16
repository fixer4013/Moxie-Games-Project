using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsSlamScene : MonoBehaviour
{
    Animator anim;
    AudioSource audioS;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
        StartCoroutine(DoorSlamming());
    }
    IEnumerator DoorSlamming()
    {
        while (true)
        {
            anim.Play("OpenDoor");
            anim.speed = 1.5f;
            yield return new WaitForSeconds((5f/12f)/anim.speed);
            audioS.Play();
            yield return new WaitForSeconds(Random.Range(0, 0.2f));
        }


    }
}
