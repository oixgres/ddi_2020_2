using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteractable : Interactable
{
    Rigidbody rb;
    public float torque;
    bool interactionSet;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(interactionSet)
            rb.AddTorque(transform.up * torque * -1f);
    }

    public override void interact()
    {
        base.interact();
        interactionSet = true;
    }
}
