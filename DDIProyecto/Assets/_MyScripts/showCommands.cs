using IBM.Watsson.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showCommands : MonoBehaviour
{
    VoiceCommandProcessor voiceCommandProcessor;
    void Start()
    {
        voiceCommandProcessor = VoiceCommandProcessor.VoiceCommandProcessorInstance;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = voiceCommandProcessor.transcript;
    }
}
