using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class SoundSensor : MonoBehaviour
{
    public string brokerIpAdress = "127.0.0.1";
    public int brokerPort = 1883;
    public string motionTopic = "casa/patio/movimiento";

    public string soundTopic = "casa/afuera/sonido";

    public Text musicMessage; 
    public GameObject audioSource;
    public AudioClip song;
    private AudioSource reproductor;
    private AudioClip prevSong;

    private MqttClient client;
    private string lastMessage;

    private void Awake()
    {
        reproductor = audioSource.GetComponent<AudioSource>();

        musicMessage.text = reproductor.clip.name;
    }

    void Start()
    {
        client = new MqttClient(IPAddress.Parse(brokerIpAdress), brokerPort, false, null);
        string clientID = Guid.NewGuid().ToString();
        client.Connect(clientID);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entro");
            client.Publish(motionTopic, System.Text.Encoding.UTF8.GetBytes("Traspaso"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

            prevSong = reproductor.clip;
            reproductor.Stop();
            reproductor.clip = song;
            reproductor.Play();

            musicMessage.text = song.name;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Salio");
            client.Publish(motionTopic, System.Text.Encoding.UTF8.GetBytes("Salio"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

            reproductor.Stop();
            reproductor.clip = prevSong;
            reproductor.Play();

            musicMessage.text = prevSong.name;
        }
    }

    private void OnApplicationQuit()
    {
        client.Disconnect();
    }
}
