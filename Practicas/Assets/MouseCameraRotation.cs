using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MouseCameraRotation : MonoBehaviour
{
    public bool clampVertiLRotation = true;
    public float XSensitivity = 1f, YSensitivity = 1f;
    public float MinimumX = -45F;
    public float MaximumX = 45F;

    public float smoothTime = 5f;

    public GameObject character;

    private Quaternion characterRot;
    private Quaternion cameraRot;

    // Start is called before the first frame update
    void Start()
    {
       // cameraRot = this.transform.localRotation;
       // characterRot = character.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
        float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;
/*
        characterRot *= Quaternion.Euler(0f, yRot, 0f);
        cameraRot *= Quaternion.Euler(-xRot, 0f, 0f);
        if(clampVertiLRotation)
            cameraRot = ClampRotationAroundXAxis(cameraRot);
*/
  //      character.transform.localRotation = Quaternion.Slerp(character.transform.localRotation, characterRot, smoothTime * Time.deltaTime);
  //      this.transform.localRotation = Quaternion.Slerp(this.transform.localRotation, cameraRot, smoothTime * Time.deltaTime);
 

        character.transform.rotation *= Quaternion.Euler(0f, yRot, 0f);
        this.transform.rotation *= Quaternion.Euler(-xRot, 0f, 0f);



        if (clampVertiLRotation)
            this.transform.rotation = ClampRotationAroundXAxis(this.transform.rotation);

    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

}
