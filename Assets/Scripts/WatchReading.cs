using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class WatchReading : MonoBehaviour
{
    public GameObject serial;
    private SerialCom serialCom;
    private Text displayedtext;

    // Start is called before the first frame update
    void Start()
    {
        displayedtext = this.GetComponent<Text>();
        serialCom = serial.GetComponent<SerialCom>();
    }

    // Update is called once per frame
    void Update()
    {
        displayedtext.text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString("0") + "\n" + "BPM:" + serialCom.b + "\n" + "Steps:" + serialCom.steps;
    }
}
