using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushInteractable : Interactable
{
    public float pushspeed;
    public Vector3 kickDirection;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void interact()
    {
        base.interact();
        Debug.Log("Pushing...");

        if (rb != null)
            rb.AddForce(kickDirection * 100, ForceMode.Acceleration);
    }
}
