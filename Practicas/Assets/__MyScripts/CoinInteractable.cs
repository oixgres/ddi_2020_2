using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteractable : Interactable
{
    Rigidbody rb;
    public float torque;
    bool interactionSet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.interact();
    }
}
