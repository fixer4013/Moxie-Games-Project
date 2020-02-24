using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionCharacters : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -50f;
    public float jumpHeight = 5f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundLayer;

    public Vector3 gravityVelocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = -2f;
        }

        if (isGrounded)
        {
            controller.slopeLimit = 45f;
        }
        else
        {
            controller.slopeLimit = 90f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            gravityVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        gravityVelocity.y += gravity * Time.deltaTime;

        controller.Move(transform.up * gravityVelocity.y * Time.deltaTime);
    }
}
