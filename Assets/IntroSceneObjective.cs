using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroSceneObjective : MonoBehaviour
{
    public Animator anim;
    bool activated;
    public TextMeshProUGUI tmp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() && !activated)
        {
            anim.Play("InstructionsFadeIn");
            tmp.enabled = true;
            Invoke("FadeOut", 10f);
            activated = true;
        }
    }

    void FadeOut()
    {
        anim.Play("InstructionsFadeOut");
    }
}
