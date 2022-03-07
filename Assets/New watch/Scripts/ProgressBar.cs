using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProgressBar : MonoBehaviour
{
    public RectTransform progessbar;
    public float timeStep = 1f;
    public float stepAngle = 6f;

    private float startTime;

    void Start()
    {
        startTime = Time.time;

        //Initiale Rotation Image -> definiert Startwert der Progressbar
        DateTime dateTime = DateTime.Now;
        int second = dateTime.Second;
        Vector3 barAngle = progessbar.localEulerAngles;
        barAngle.z = (360/60) * second;
        progessbar.localEulerAngles = barAngle + new Vector3(0,0,6);
    }

    void Update()
    {

        if (Time.time - startTime >= timeStep)
        {
            Vector3 barAngle = progessbar.localEulerAngles;
            barAngle.z += stepAngle;

            progessbar.localEulerAngles = barAngle;

            startTime = Time.time;
        }
    }
}
