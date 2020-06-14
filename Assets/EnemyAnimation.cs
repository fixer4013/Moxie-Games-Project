using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    public NavMeshAgent ai;
    public Animator anim;

    void Update()
    {
        if (ai.velocity != Vector3.zero)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }


    }
}
