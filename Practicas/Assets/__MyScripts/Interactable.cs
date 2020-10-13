using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    bool inArea = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void interact()
    { 
    
    }

    // Update is called once per frame
    void Update()
    {
        if (inArea && Input.GetKeyDown(KeyCode.G))
            interact();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        inArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        inArea = false;
    }
}
