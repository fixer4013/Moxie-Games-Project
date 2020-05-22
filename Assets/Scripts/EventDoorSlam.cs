using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDoorSlam : MonoBehaviour
{
    public DoorMechanics dm;
    public Animator anim;
    public GameObject player;
    public AudioSource audioS;

    bool pickedUp;
    bool closeToDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            if (Vector3.Distance(player.transform.position, dm.gameObject.transform.position) <= 3 && !closeToDoor)
            {
                closeToDoor = true;
                StartCoroutine(DoorSlam());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!pickedUp)
        {
            pickedUp = true;
            dm.enabled = true;
            anim.Play("EventDoorSlam");
            anim.speed = 0;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    IEnumerator DoorSlam()
    {
        anim.speed = 1;
        yield return new WaitForSeconds(0.1f);
        audioS.Play();
        dm.enabled = true;
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
