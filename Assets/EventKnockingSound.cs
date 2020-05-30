using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EventKnockingSound : MonoBehaviour
{
    public AudioSource audioKnocking;
    public AudioSource audioScare;

    public NavMeshAgent enemyNav;
    public GameObject enemy;

    Transform previousEnemyTransform;
    public Transform enemyTransform;

    public GameObject enemyTrigger;

    public Flickering lightFlicker;

    public bool pickedUp;



    private void OnTriggerEnter(Collider other)
    {
        if (!pickedUp && other.GetComponent<PlayerMovement>())
        {
            pickedUp = true;
            GetComponent<BoxCollider>().enabled = false;
            Invoke("EnableEvent", 3);
        }
    }

    void EnableEvent()
    {
        enemyTrigger.SetActive(true);
        audioKnocking.Play();
        lightFlicker.enabled = true;
    }

    public IEnumerator AppearEnemy()
    {
        enemyNav.enabled = false;
        previousEnemyTransform = enemy.transform;
        enemy.transform.position = enemyTransform.position;
        enemy.transform.rotation = enemyTransform.rotation;
        audioScare.Play();
        yield return new WaitForSeconds(1);

        enemyNav.enabled = true;
        enemy.transform.position = previousEnemyTransform.position;
    }
}
