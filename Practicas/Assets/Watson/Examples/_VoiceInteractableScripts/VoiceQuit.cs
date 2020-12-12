using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceQuit : VoiceInteractable
{
    public override void VoiceInteract(string action)
    {
        base.VoiceInteract(action);

        if (action == "adios" || action == "adiós")
        {
            Application.Quit();
            Debug.Log("Cerrando Aplicacion");
        }
    }
}
