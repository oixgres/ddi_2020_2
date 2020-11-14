using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ThirdPersonCameraController : MonoBehaviour //36:37
{
    public float RotationSpeed = 1;
    public Joystick joy;
    public Transform target, player;
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
         camControl();
    }

     void camControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(mouseX, mouseY, 0);
        player.rotation = Quaternion.Euler(0, mouseY, 0);
    }
}
