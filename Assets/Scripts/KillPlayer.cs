using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public Transform player;
    public DimensionCamera cam;
    public NavMeshAgent nav;
    bool killingPlayer;

    public Text text;
    public Image image;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 3 && !killingPlayer)
        {
            Kill();
        }
    }

    void Kill()
    {
        killingPlayer = true;
        player.GetComponent<PlayerMovement>().enabled = false;
        cam.enabled = false;
        nav.speed = 0;


        text.enabled = true;
        image.enabled = true;
        Invoke("RestartScene", 2f);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
