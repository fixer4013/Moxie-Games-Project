using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorEndGame : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    public BoxCollider boxCol;
    public Animator animFadeOut;

    bool open;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!open)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 10)
            {
                open = true;
                StartCoroutine(OpenElevator());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CloseElevator());
    }

    IEnumerator OpenElevator()
    {
        anim.Play("ElevatorDoorsIntroOpen");
        yield return new WaitForSeconds(2f);
        boxCol.enabled = false;
    }

    IEnumerator CloseElevator()
    {
        anim.Play("ElevatorDoorsIntroClose");
        boxCol.enabled = true;
        yield return new WaitForSeconds(3.5f);
        animFadeOut.Play("IntroFadeOut");
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(0);
    }
}
