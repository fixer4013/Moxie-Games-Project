using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKillPlayer : MonoBehaviour
{
    public GameObject player;
    public DimensionCamera cam;
    public Animator anim;

    bool killingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!killingPlayer)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 2.3)
            {
                killingPlayer = true;
                cam.enabled = false;
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<CharacterController>().enabled = false;
                anim.Play("IntroFadeOut");
                Invoke("Death", 6);
            }
        }

    }

    void Death()
    {
        SceneManager.LoadScene(0);
    }
}
