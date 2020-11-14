using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CarryObjects :MonoBehaviour
{
    bool inArea = false, have = false;
    Rigidbody rb;
    MeshCollider md;

    public Rigidbody character;
    public Vector3 distance;
    public Transform interactionZone;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        md = GetComponent<MeshCollider>();

    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.L) && inArea)
        if(CrossPlatformInputManager.GetButtonDown("Fire3") && inArea)
        {
            Debug.Log("Levantando");
            
            have = !have;

            if (have)
            {
                rb.transform.SetParent(interactionZone);
                rb.transform.position += distance;
                md.isTrigger = true;
                rb.useGravity = false;
                rb.isKinematic = true;
            }
            else
            {
                rb.transform.SetParent(null);
                rb.transform.position -= distance;
                md.isTrigger = false;
                rb.useGravity = true;
                rb.isKinematic = false;
            }
        }
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
