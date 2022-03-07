using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimerGenerator : MonoBehaviour
{
    public Text dateText;
    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        DateTime dateTime = DateTime.Now;

        dateText.text = dateTime.ToLongDateString();
        timeText.text = dateTime.ToShortTimeString();
    }
}
