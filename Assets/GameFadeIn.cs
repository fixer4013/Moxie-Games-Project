using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFadeIn : MonoBehaviour
{
    public Animator fadeIn;
    public GameObject player;
    public DimensionCamera cam;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        cam.enabled = false;

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        fadeIn.Play("IntroFadeIn");
        yield return new WaitForSeconds(2.5f);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        cam.enabled = true;
    }
}
