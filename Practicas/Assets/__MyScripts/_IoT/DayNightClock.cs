using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightClock : MonoBehaviour
{
    public int secondsInFullDay; 
    public Text clock;
    public float hour = 0, min = 0, second = 0;
    public List<Light> lamps;

    private float day;
    private float dayNormalized;
    private bool onOff = false; //true prendido, off apagado
    void Start()
    {
        day = hour / 24;
        turnOnOffLights(lamps);
    }

    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / secondsInFullDay;
        dayNormalized = day % 1f;

        hour = (dayNormalized * 24f);
        min = ((hour % 1f) * 60f);
        second = ((min % 1f) * 60f);

        clock.text = Mathf.Floor(hour).ToString() + ":" + Mathf.Floor(min).ToString() + ":" + Mathf.Floor(second).ToString();

        if (hour > 16 && hour < 17 && !onOff)
        {
            turnOnOffLights(lamps);
            onOff = true;
        }
        else
            if (hour > 6 && hour < 7 && onOff)
            {
                turnOnOffLights(lamps);
                onOff = false;
            }
    }

    void turnOnOffLights(List<Light> lights)
    {
        for (int i = 0; i < lights.Count; i++)
            lights[i].enabled = !lights[i].enabled;
    
    }
}
