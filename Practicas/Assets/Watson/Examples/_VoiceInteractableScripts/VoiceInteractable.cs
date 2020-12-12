using IBM.Watsson.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceInteractable : MonoBehaviour
{

    private VoiceCommandProcessor voiceCommandProcessor;


    // Start is called before the first frame update
    void Start()
    {
        voiceCommandProcessor = VoiceCommandProcessor.VoiceCommandProcessorInstance;
        voiceCommandProcessor.onVoiceCommand += VoiceInteract;
    }

    // Update is called once per frame
    public virtual void VoiceInteract(string action)
    {
        Debug.Log("Realizando: "+action);
    }
}
