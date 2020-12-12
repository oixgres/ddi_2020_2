using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceMusic : VoiceInteractable
{
    public List<AudioClip> clips;
    private int clipsCount = 0;
    private bool wasPlaying = false;
    private AudioSource audio;

    // Start is called before the first frame update
    void Awake()
    {
        audio = this.GetComponent<AudioSource>();
        
        if(clips != null)
            audio.clip = clips[0];
    }

    // Update is called once per frame
    public override void VoiceInteract(string action)
    {
        base.VoiceInteract(action);

        if (audio != null)
        {
            if (action == "música" && audio.isPlaying == false)
            {
                audio.Play();
                Debug.Log("Reproduciendo: " + audio.clip.name);
            }

            if (action == "silencio" && audio.isPlaying)
            {
                audio.Stop();
                Debug.Log("Parando: " + audio.clip.name);
            }

            if ((action == "siguiente" || action == "anterior") && clips.Count > 1)
            {
                if (audio.isPlaying)
                {
                    audio.Stop();
                    wasPlaying = true;
                }

                if (action == "siguiente")
                {
                    clipsCount++;
                    if (clipsCount >= clips.Count)
                        clipsCount = 0;
                }
                else
                {
                    clipsCount--;
                    if (clipsCount < 0)
                        clipsCount = clips.Count - 1;
                }
                audio.clip = clips[clipsCount];

                if (wasPlaying)
                {
                    wasPlaying = false;
                    audio.Play();
                    Debug.Log("Reproduciendo: " + audio.clip.name);
                }
            }
        }
    }
}
