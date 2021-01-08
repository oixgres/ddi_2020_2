using IBM.Watsson.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tasksController : MonoBehaviour
{
    private VoiceCommandProcessor voiceCommandProcessor;

    public string taskText;
    public Text task;

    private int tasksCompleted = 0;

    private void Start()
    {
        voiceCommandProcessor = VoiceCommandProcessor.VoiceCommandProcessorInstance;
        task.text = taskText + " (0/3)";
    }
    void Update()
    {
        if (tasksCompleted < voiceCommandProcessor.numberTasksCompleted)
        {
            tasksCompleted++;
            task.text = taskText + " ("+tasksCompleted.ToString()+"/3)";

            if (tasksCompleted == 3)
                task.color = Color.green;
               
        }
    }
}
