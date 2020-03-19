using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAudio : MonoBehaviour
{
    public Rooms room;
    public AudioSource audioS;
    public AudioClip goodSound;
    public AudioClip badSound;

    void Update()
    {
        if (room.roomCondition == 1 && audioS.clip != goodSound) //good
        {
            audioS.clip = goodSound;
        }
        if (room.roomCondition == 2 && audioS.clip != badSound) //bad
        {
            audioS.clip = badSound;
        }
    }
}
