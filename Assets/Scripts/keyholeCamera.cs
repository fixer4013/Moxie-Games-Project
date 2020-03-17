using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyholeCamera : MonoBehaviour
{
    public float mouseSensitivity = 15f;

    float xRotation = 0f;
    float yRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -15f, 15f);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -20f, 20f);


        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
