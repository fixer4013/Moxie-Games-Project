using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroSceneObjective : MonoBehaviour
{
    public Animator anim;
    bool activated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() && !activated)
        {
            anim.Play("InstructionsFadeIn");
            Invoke("FadeOut", 10f);
            activated = true;
        }
    }

    void FadeOut()
    {
        anim.Play("InstructionsFadeOut");
    }
}
