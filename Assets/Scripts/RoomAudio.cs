using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAudio : MonoBehaviour
{
    public Rooms room;
    public AudioSource audioS;
    public AudioClip[] goodSounds;
    public AudioClip[] badSounds;
    bool isGood;

    private void Start()
    {
        if (room.roomCondition == 1 && goodSounds.Length != 0)
        {
            isGood = true;
            int rand = Random.Range(0, goodSounds.Length);
            audioS.clip = goodSounds[rand];
        }

        if (room.roomCondition == 2 && badSounds.Length != 0)
        {
            isGood = false;
            int rand = Random.Range(0, badSounds.Length);
            audioS.clip = badSounds[rand];
        }
    }

    void Update()
    {
        if (room.roomCondition == 1 && !isGood && goodSounds.Length != 0) //good
        {
            isGood = true;
            int rand = Random.Range(0, goodSounds.Length);
            audioS.clip = goodSounds[rand];
        }

        if (room.roomCondition == 2 && isGood && badSounds.Length != 0) //bad
        {
            isGood = false;
            int rand = Random.Range(0, badSounds.Length);
            audioS.clip = badSounds[rand];
        }
    }
}
