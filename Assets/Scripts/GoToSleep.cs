using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSleep : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public Animator introFadeOut;

    public IEnumerator Sleep()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<LookAtInteractable>().enabled = false;
        cam.GetComponent<DimensionCamera>().enabled = false;

        introFadeOut.Play("IntroFadeOut");

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
