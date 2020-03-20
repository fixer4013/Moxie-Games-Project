using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSound : MonoBehaviour
{
    public PlayerMovement player;
    public AudioSource audioS;
    public AudioClip walking;
    public AudioClip running;
    bool isStoppingAudio;
    // Update is called once per frame

    void Update()
    {
        if (player)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                if (!player.sprinting)
                {
                    audioS.clip = walking;
                }
                else
                {
                    audioS.clip = running;
                }

                isStoppingAudio = false;
                audioS.volume = 1;
                if (!audioS.isPlaying)
                {
                    audioS.Play();
                    StopAllCoroutines();
                }
            }
            else
            {
                if (!isStoppingAudio)
                {
                    StartCoroutine(StopAudio());
                }
            }
        }

    }

    IEnumerator StopAudio()
    {
        isStoppingAudio = true;
        for (float i = 0; i < 0.33f; i += Time.deltaTime)
        {
            audioS.volume -= Time.deltaTime * 3;
            yield return 0;
        }
    }
}
