using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBallInteractible :Interactable
{
    // Start is called before the first frame update
    Rigidbody rb;
    public Vector3 kickDirection;
    public float kickForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    public override void interact()
    {
        base.interact();
        Debug.Log("Pateando");

        if (rb != null)
            rb.AddForce(kickDirection * kickForce, ForceMode.Force);
        
    
    }
}
