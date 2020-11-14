using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Interactable : MonoBehaviour
{
    bool inArea = false;

    public virtual void interact()
    {
        Debug.Log("Interactuando...");
    }

    // Update is called once per frame
    void Update()
    {
     //   if (inArea && Input.GetKeyDown(KeyCode.G))
        if(inArea && CrossPlatformInputManager.GetButtonDown("Fire1"))
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
