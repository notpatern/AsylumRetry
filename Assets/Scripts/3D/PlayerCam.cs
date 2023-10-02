using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform Camera;

    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!ButtonScript.Paused)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * sensX * PlayerPrefs.GetFloat("Sensitivity") * 0.5f * 0.002f;
            float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * PlayerPrefs.GetFloat("Sensitivity") * 0.5f * 0.002f;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            Camera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}