using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class LightSensor : MonoBehaviour
{
    public string brokerIpAdress = "127.0.0.1";
    public int brokerPort = 1883;
    public string motionTopic = "casa/patio/movimiento";


    public string lightTopic = "casa/lampara/iluminacion";
    public string lightName;
    public Text lightMessage;

    private MqttClient client;
    private string lastMessage;
    
    private Light light;
    

    private void Awake()
    {
        light = this.GetComponent<Light>();

        lightMessage.text = (lightName + ": OFF");
    }

    void Start()
    {
        client = new MqttClient(IPAddress.Parse(brokerIpAdress), brokerPort, false, null);
        string clientID = Guid.NewGuid().ToString();
        client.Connect(clientID);

        light.enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Luz prendida");
            client.Publish(motionTopic, System.Text.Encoding.UTF8.GetBytes("Luz prendida"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

            light.enabled = true;
            lightMessage.text = lightName + ": ON";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Luz apagada");
            client.Publish(motionTopic, System.Text.Encoding.UTF8.GetBytes("Luz apagada"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

            light.enabled = false;
            lightMessage.text = lightName + ": OFF";
        }
    }

    private void OnApplicationQuit()
    {
        client.Disconnect();
    }
}
