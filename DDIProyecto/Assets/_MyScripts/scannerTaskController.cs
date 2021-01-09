using IBM.Watsson.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scannerTaskController : MonoBehaviour
{
    private VoiceCommandProcessor voiceCommandProcessor;
    private int points = 27;

    public string taskText;
    public Text taskCompleted;
    public Text task; 

    // Start is called before the first frame update
    void Start()
    {
        voiceCommandProcessor = VoiceCommandProcessor.VoiceCommandProcessorInstance;
    }

    // Update is called once per frame
    void Update()
    {
        if (points <= 28)
        {
            if (points >= 28)
            {
                points = 1;
                task.text = taskText;
            }    

            points++;
            task.text = task.text + taskText;

            if (voiceCommandProcessor.scannerCompleted)
                taskCompleted.color = Color.green;
        }
    }
}
