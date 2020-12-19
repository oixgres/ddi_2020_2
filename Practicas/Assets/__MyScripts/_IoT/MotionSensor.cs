using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class MotionSensor : MonoBehaviour
{
    public string brokerIpAdress = "127.0.0.1";
    public int brokerPort = 1883;
    public string motionTopic = "casa/patio/movimiento";

    private MqttClient client;
    private string lastMessage;


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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Salio");
            client.Publish(motionTopic, System.Text.Encoding.UTF8.GetBytes("Salio"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
    }

    private void OnApplicationQuit()
    {
        client.Disconnect();
    }

}
