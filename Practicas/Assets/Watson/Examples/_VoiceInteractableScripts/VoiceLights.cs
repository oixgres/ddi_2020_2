using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLights : VoiceInteractable
{
    private Light light;

    // Start is called before the first frame update
    void Awake()
    {
        light = this.GetComponent<Light>();
    }

    public override void VoiceInteract(string action)
    {
        base.VoiceInteract(action);

        if (light != null && action == "oscurece")
        {
            if (light.intensity > 0)
                light.intensity--;

            Debug.Log("Nivel de luz: " + light.intensity);
        }


        if (light != null && action == "brilla")
        {
            if (light.intensity < 6)
                light.intensity++;

            Debug.Log("Nivel de luz: " + light.intensity);
        }
            


    }
}
