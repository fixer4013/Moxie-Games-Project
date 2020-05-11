using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClothGuyRandomRoaming : MonoBehaviour
{
    public Transform[] targets;
    public NavMeshAgent nav;

    public ParticleSystem par;
    ParticleSystem.EmissionModule em;

    // Start is called before the first frame update
    void Start()
    {
        em = par.emission;
        //StartCoroutine(RandomBurst());
        em.rateOverTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!nav.hasPath)
        {
            ChooseTransform();
        }
    }

    void ChooseTransform()
    {
        int rand = Random.Range(0, targets.Length);
        nav.SetDestination(targets[rand].transform.position);
    }

    IEnumerator RandomBurst()
    {
        while (true)
        {
            var randomNum = Random.Range(10, 15);
            em.rateOverTime = 0;
            yield return new WaitForSeconds(randomNum);
            em.rateOverTime = 100;
            var currentTime = Time.time;
            Debug.Log(currentTime);
            while (Time.time < currentTime + 1)
            {
                nav.velocity = nav.transform.forward * 10;
                yield return 0;
            }
        }

    }
}
