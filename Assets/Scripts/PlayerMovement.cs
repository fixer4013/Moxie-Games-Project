using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Slider staminaBar;
    public AudioSource audio;

    public float walkSpeed = 3f;
    public float sprintSpeed = 6f;
    public float speed;
    float gravity = -10f;
    public float x;
    public float z;

    //public float rechargeStaminaSpeed;
    //bool isRecharging;

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
            //StopAllCoroutines();
            //isRecharging = false;
        }
        else
        {
            speed = walkSpeed;
            //if (!isRecharging)
            //{
            //    StartCoroutine(StaminaRecharge());
            //}
        }
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(Vector3.up * gravity * Time.deltaTime);

        //if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        //{
        //    staminaBar.value -= Time.deltaTime * 0.2f;
        //}
    }

    //IEnumerator StaminaRecharge()
    //{
    //    isRecharging = true;
    //    yield return new WaitForSeconds(2f);
    //    while (true)
    //    {
    //        staminaBar.value += Time.deltaTime * rechargeStaminaSpeed / 100;
    //        yield return 0;
    //    }
    //}
}
