using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehindDoor : MonoBehaviour
{
    public AudioSource sounds;
    public Interactable door;

    private void Update()
    {
        if (door.listening)
        {
            if (sounds.isPlaying == false)
            {
                sounds.Play();
            }
        }
        else
        {
            sounds.Stop();
        }
    }

}
