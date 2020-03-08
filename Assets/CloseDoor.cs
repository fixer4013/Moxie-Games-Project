﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public Animator anim;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("test");
        if (collision.gameObject.tag == "Player")
        {
            anim.Play("CloseDoor");
            Destroy(this.gameObject);
            return;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if (other.tag == "Player")
        {
            anim.Play("DoorClose");
            Destroy(this.gameObject);
            return;
        }
    }

}
