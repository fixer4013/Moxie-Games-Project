using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip[] clips;

    private void Start()
    {
        StartCoroutine(PlayEnemySounds());
    }

    IEnumerator PlayEnemySounds()
    {
        while (true)
        {
            audioS.Stop();
            audioS.clip = clips[Random.Range(0, clips.Length)];
            audioS.Play();

            yield return new WaitForSeconds(audioS.clip.length);
        }

    }
}
