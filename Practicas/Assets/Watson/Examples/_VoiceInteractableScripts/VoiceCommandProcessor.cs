using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IBM.Watsson.Examples
{
    public class VoiceCommandProcessor : MonoBehaviour
    {
        static protected VoiceCommandProcessor s_VoiceCommandProcessorInstance;
        static public VoiceCommandProcessor VoiceCommandProcessorInstance { get { return s_VoiceCommandProcessorInstance; } }


        public delegate void OnVoiceCommand(string action);
        public OnVoiceCommand onVoiceCommand;

        public List<string> actions;
        public List<string> specialActions;
        public List<GameObject> spawnablePrefabs;

        private void Awake()
        {
            s_VoiceCommandProcessorInstance = this;
        }

        public  void create(string transcript)
        {
            string [] words = transcript.Split(' ');

            foreach (var word in words)
            {
                if (actions.Contains(word.ToLower()))
                {
                    if (onVoiceCommand != null)
                        onVoiceCommand.Invoke(word.ToLower());

                    return;
                }
            }

            foreach (var word in words)
            {
                if (specialActions.Contains(word.ToLower()))
                {
                    if (word.ToLower() == "invoca")
                        spawnObjects(words);

                    return;  
                }
            }
        
        }

        void spawnObjects(string [] words)
        {
            foreach (var word in words)
            {
                foreach (var prefab in spawnablePrefabs)
                    if (prefab.name == word.ToLower())
                    {
                        Instantiate(prefab, Vector3.zero, Quaternion.identity);
                        Debug.Log("Invocando rectanculo");
                    }
            }
        }
    }
}
