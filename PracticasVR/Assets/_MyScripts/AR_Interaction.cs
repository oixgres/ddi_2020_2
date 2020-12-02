using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Interaction : MonoBehaviour
{
    public string action;
    public Animator animator;

    private bool isActing = false;

    void OnMouseDown()
    {
        isActing = !isActing;
        Debug.LogWarning("CHANGE");
    }

    private void Update()
    {
        if (isActing)
        {
            animator.Play(action);
            Debug.Log(action);
        }
        else
            animator.Play("None");
    }
}
