using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPeekABoo : MonoBehaviour
{
    public DoorMechanics dm;
    public RawImage rawIm;
    public Texture peekABooTexture;
    public Texture originalTexture;
    public GameObject cam;

    public LockedDoorEndHallway LDRH;

    public bool pickedUp;
    public bool inEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            if (cam.activeSelf == true && !inEvent)
            {
                inEvent = true;
                StartCoroutine(PeekABoo());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!pickedUp)
        {
            pickedUp = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            rawIm.texture = peekABooTexture;
            dm.locked = true;
            Debug.Log("test");
            LDRH.amountOfEventsToBeDone -= 1;
        }
    }

    IEnumerator PeekABoo()
    {
        Debug.Log("test2");
        dm.locked = false;
        yield return new WaitForSeconds(1f);
        rawIm.texture = originalTexture;
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
