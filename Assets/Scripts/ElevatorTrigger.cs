using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        anim.Play("ElevatorDoorsIntroClose");
        this.gameObject.SetActive(false);
    }
}
