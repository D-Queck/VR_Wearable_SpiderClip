using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class Logging : MonoBehaviour
{
    public SerialCom serialCom;
    string filepath;
    StreamWriter tw;
    float timePassed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //C:\Users\VR\Desktop\VR TESTING - Copy\Experiment\Logs
        filepath = "C:/Users/VR/Desktop/VR TESTING - Copy/Experiment/Logs/" + DateTime.UtcNow.ToLocalTime().ToString("yyyyMMMMddHHmm") + ".csv";
        tw = new StreamWriter(filepath, true);
    }


    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed < 1f)
        {
            return;
        }

        timePassed = 0f;

        if (serialCom.b_acc)
        {
            WriteCSV();
            serialCom.b_acc = false;
        }
    }


    void OnApplicationQuit()
    {
        tw.Dispose();
    }


    public void WriteCSV()
    {
        tw.WriteLine(DateTime.UtcNow.ToLocalTime().ToString("HHmmss") + ","  + serialCom.ax.ToString() + "," + serialCom.ay.ToString() + "," + serialCom.az.ToString() 
            + "," + serialCom.rx.ToString() + "," + serialCom.ry.ToString() + "," + serialCom.rz.ToString()
             + "," + serialCom.b.ToString() + "," + serialCom.c.ToString());
        //tw.Close(); // if used , a new stream writer has to be opened
    }

}
