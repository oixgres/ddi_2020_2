using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeButton : MonoBehaviour
{
    public GameObject button;
    public GameObject fakebutton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button.SetActive(true);
            fakebutton.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button.SetActive(false);
            fakebutton.SetActive(true);
        }

    }

}
