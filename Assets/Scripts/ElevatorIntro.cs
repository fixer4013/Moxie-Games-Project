using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorIntro : MonoBehaviour
{
    public GameObject player;
    public DimensionCamera cam;

    public AudioSource aud;
    public AudioClip elevatorSound;
    public AudioClip plingSound;

    public Animator animFadeIn;

    public Animator animElevatorDoors;
    private void Awake()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        cam.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroElevator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IntroElevator()
    {
        aud.clip = elevatorSound;
        aud.Play();
        yield return new WaitForSeconds(11f);

        for (float i = 0; i < 2; i += Time.deltaTime)
        {
            aud.volume = 1 - i/2;
            yield return 0;
        }
        yield return new WaitForSeconds(1.5f);
        aud.clip = plingSound;
        aud.volume = 1;
        aud.Play();
        yield return new WaitForSeconds(1f);

        animFadeIn.Play("IntroFadeIn");
        yield return new WaitForSeconds(1.5f);
        animElevatorDoors.Play("ElevatorDoorsIntroOpen");
        yield return new WaitForSeconds(3.5f);

        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        cam.enabled = true;
        yield return 0;
    }
}
