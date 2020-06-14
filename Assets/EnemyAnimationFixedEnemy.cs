using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationFixedEnemy : MonoBehaviour
{
    public Animator anim;
    public Transform enemy;
    Vector3 prefEnemyPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.position != prefEnemyPosition)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
        prefEnemyPosition = enemy.position;
    }
}
