using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceKickBall : VoiceInteractable
{

    public Vector3 kickDirection;
    public float kickForce = 30f;
    private Rigidbody rb;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public override void VoiceInteract(string action)
    {
        base.VoiceInteract(action);

        if ((action == "patea" || action == "patear") && rb != null)
        {
            rb.AddForce(kickDirection * kickForce, ForceMode.Force);
            Debug.Log("Pelota pateada");
        }
    }
}
