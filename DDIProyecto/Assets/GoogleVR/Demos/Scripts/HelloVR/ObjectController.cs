//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google Inc.">
// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleVR.HelloVR
{
    using IBM.Watsson.Examples;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using System.Collections.Generic;

    /// <summary>Controls interactable teleporting objects in the Demo scene.</summary>
    [RequireComponent(typeof(Collider))]
    public class ObjectController : MonoBehaviour
    {
        /// <summary>
        /// The material to use when this object is inactive (not being gazed at).
        /// </summary>
        public Material inactiveMaterial;

        /// <summary>The material to use when this object is active (gazed at).</summary>
        public Material gazedAtMaterial;

        private Vector3 startingPosition;
        private Renderer myRenderer;

        /*My*/
        public string action;
        public GameObject player;
        private VoiceCommandProcessor voiceCommandProcessor;

        /*flags*/
        private bool isGazed = false;
        private bool timeStartFlag = false;
        private bool numbersGame = false;
        private bool scannerGame = false;

        /*timers*/
        private float offsetTime = 2f;
        private float time = 0f;

        /*numbers game*/
        public string panelName = ""; 
        public List<string> numbers = new List<string>{ "uno", "2", "3" };


        /// <summary>Sets this instance's GazedAt state.</summary>
        /// <param name="gazedAt">
        /// Value `true` if this object is being gazed at, `false` otherwise.
        /// </param>
        /// 
        public void SetGazedAt(bool gazedAt)
        {
            /*
            if(voiceCommandProcessor.actions.Contains(action))
                voiceCommandProcessor.transcriptFlag = gazedAt;
            */
            //interactions.interact(voiceCommandProcessor.transcript, player, this.transform);
            isGazed = gazedAt;

            if (inactiveMaterial != null && gazedAtMaterial != null)
            {
                myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
                return;
            }
        }

        /// <summary>Resets this instance and its siblings to their starting positions.</summary>
        public void Reset()
        {
            int sibIdx = transform.GetSiblingIndex();
            int numSibs = transform.parent.childCount;
            for (int i = 0; i < numSibs; i++)
            {
                GameObject sib = transform.parent.GetChild(i).gameObject;
                sib.transform.localPosition = startingPosition;
                sib.SetActive(i == sibIdx);
            }
        }

        /// <summary>Calls the Recenter event.</summary>
        public void Recenter()
        {
#if !UNITY_EDITOR
            GvrCardboardHelpers.Recenter();
#else
            if (GvrEditorEmulator.Instance != null)
            {
                GvrEditorEmulator.Instance.Recenter();
            }
#endif  // !UNITY_EDITOR
        }

        /// <summary>Teleport this instance randomly when triggered by a pointer click.</summary>
        /// <param name="eventData">The pointer click event which triggered this call.</param>
        public void TeleportRandomly(BaseEventData eventData)
        {
            // Only trigger on left input button, which maps to
            // Daydream controller TouchPadButton and Trigger buttons.
            PointerEventData ped = eventData as PointerEventData;
            if (ped != null)
            {
                if (ped.button != PointerEventData.InputButton.Left)
                {
                    return;
                }
            }

            // Pick a random sibling, move them somewhere random, activate them,
            // deactivate ourself.
            int sibIdx = transform.GetSiblingIndex();
            int numSibs = transform.parent.childCount;
            sibIdx = (sibIdx + Random.Range(1, numSibs)) % numSibs;
            GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;

            // Move to random new location ±90˚ horzontal.
            Vector3 direction = Quaternion.Euler(
                0,
                Random.Range(-90, 90),
                0) * Vector3.forward;

            // New location between 1.5m and 3.5m.
            float distance = (2 * Random.value) + 1.5f;
            Vector3 newPos = direction * distance;

            // Limit vertical position to be fully in the room.
            newPos.y = Mathf.Clamp(newPos.y, -1.2f, 4f);
            randomSib.transform.localPosition = newPos;

            randomSib.SetActive(true);
            gameObject.SetActive(false);
            SetGazedAt(false);
        }

        private void Start()
        {
            voiceCommandProcessor = VoiceCommandProcessor.VoiceCommandProcessorInstance;

            startingPosition = transform.localPosition;
            myRenderer = GetComponent<Renderer>();
            SetGazedAt(false);
        }

        private void Update()
        {
            timeChecker();//espero para la emergencia

            foreach (var word in voiceCommandProcessor.words)
            {
                if (numbersGame)
                {
                    playNumbersGame(word);

                    return;
                }

                /*Protocolo para acceder a las interacciones*/
                if (voiceCommandProcessor.actions.Contains(word.ToLower()) && isGazed)
                {
                    if (word.ToLower() == action)
                    {
                        if (action == "camina")
                            voiceWalk();
                        else if (action == "emergencia")
                        {
                            timeStart(panelName, 1f);
                        }
                        else if (action == "repara")
                        {
                            numbersGame = true;
                            voiceCommandProcessor.activatePanel(panelName);
                        }
                        else if (action == "escanea")
                        {
                            scannerGame = true;
                            timeStart(panelName, 10f);
                            voiceCommandProcessor.waitingPoints = 1;
                        }
                    }
                    return;
                }
            }
            
        }

        private void voiceWalk()
        {
            float flagX = 0, flagZ = 0, playerX, playerZ, posX, posZ;

            playerX = player.transform.position.x;
            playerZ = player.transform.position.z;
            posX = this.transform.position.x;
            posZ = this.transform.position.z;

            if (playerX > posX)
                flagX = -10;
            else
                if (playerX < posX)
                    flagX = 10;
                else
                    flagX = 0;

            if (playerZ > posZ)
                flagZ = -10;
            else
                if (playerZ > posZ)
                flagZ = 10;
            else
                flagZ = 0;

            player.GetComponent<CharacterController>().Move(new Vector3(flagX, 0, flagZ) * 0.5f * Time.deltaTime);
        }

        private void timeStart(string panel, float finishTime)
        {
            /*apagamos panel de tareas y prendemos el de emergencia*/
            timeStartFlag = true;

            voiceCommandProcessor.activatePanel(panel);

            offsetTime = finishTime;
            time += Time.deltaTime;
        }

        private void timeChecker()
        {
            if (timeStartFlag)
                time += Time.deltaTime;

            if (time > offsetTime)
            {
                voiceCommandProcessor.activatePanel("TasksPanel");
                time = 0f;
                timeStartFlag = false;
                voiceCommandProcessor.transcript = "";

                if (offsetTime == 10f)
                    voiceCommandProcessor.scannerCompleted = true;
            }
        }

        private void playNumbersGame(string word)
        {
            if (numbers.Count == 0)
            {
                voiceCommandProcessor.numberTasksCompleted++;
                voiceCommandProcessor.activatePanel("TasksPanel");

                numbersGame = false;
                Destroy(this.GetComponent<EventTrigger>());
                Destroy(this.GetComponent<EventTrigger>());
            }
            else
            {
                if (numbers.Contains(word))
                    numbers.Remove(word);

                Debug.Log(numbers.Count);
            }
        }
    }
}
