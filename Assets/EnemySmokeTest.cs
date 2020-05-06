using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmokeTest : MonoBehaviour
{
    public ParticleSystem par;
    public ParticleSystem par2;
    ParticleSystem.EmissionModule em;
    ParticleSystem.EmissionModule em2;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        em = par.emission;
        em2 = par2.emission;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
            em.rateOverTime = 60;
            em2.rateOverTime = 60;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
            em.rateOverTime = 60;
            em2.rateOverTime = 60;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            em.rateOverTime = 60;
            em2.rateOverTime = 60;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            em.rateOverTime = 60;
            em2.rateOverTime = 60;
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            em.rateOverTime = 0;
            em2.rateOverTime = 0;
        }
    }
}
