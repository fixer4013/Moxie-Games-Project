using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmokeTest : MonoBehaviour
{
    public ParticleSystem par;
    ParticleSystem.EmissionModule em;
    public ParticleSystem par2;
    ParticleSystem.EmissionModule em2;
    public float speed;

    MeshRenderer mr;
    public GameObject par3;

    // Start is called before the first frame update
    void Start()
    {
        em = par.emission;
        em2 = par2.emission;
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            em.rateOverTime = 0;
            em2.rateOverTime = 0;
            mr.enabled = true;
            par3.SetActive(true);
        }
        else
        {
            em.rateOverTime = 100;
            em2.rateOverTime = 40;
            mr.enabled = false;
            par3.SetActive(false);
        }
    }
}
