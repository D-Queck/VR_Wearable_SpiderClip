using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

public class SerialCom : MonoBehaviour
{

    public string port = "COM9";
    public int baudRate = 9600;
    //to know when th next data arrives to prevent repeating data with every update 

    public bool b_acc = false;
    private bool b_rot = false;
    private bool b_bpm = false;
    private bool b_temp = false;
    private bool b_angles = false;
    private bool b_steps = false;
    public bool Activation = false;


    //Mit normalem String?
    //public string stringtest;

    private SerialPort serialPort;
    private bool streamingIsPossible = false;

    //Variablen für Sensordaten

    public int ms, b, bpm, dist, steps, c, o;    //Timestamp, Beats-Per-Minute, Distance
    public int temp;                  //Temperature
    public float ax, ay, az;            //Acceleration
    public float rx, ry, rz;            //Rotation    
    public float roll, pitch, yaw;      //Euler Angles
    public float w, x, y, z;            //Quaternions    
    public Vector3 eulerangles;
    private Quaternion quat;
    float timet = 0;

    // Super-early
    private void Awake()
    {

    }



    // Start is called before the first frame update

    void Start()
    {
        OpenGate(); //create the port and start reading
        //Activation = true; //ativation indicator for the watch ui
        //InvokeRepeating("SendData", 1.0f, 1.0f);     
    }



    //Update is called once per frame
    void Update()
    {
        if (streamingIsPossible && Time.time > timet)
        {
            timet += 0.25f;

            string sensorData = ReadSerialPort();

            if (sensorData != null)
            {
                Activation = true; //activation indicator for the watch ui
                //Debug.Log("sensorData:" + sensorData);
                UpdateVariables(sensorData);
                b_acc = true;
                b_angles = true;
                b_bpm = true;
                b_rot = true;
                b_temp = true;
                b_steps = true;


            }
        }
    }


    //CustomFunktionen


    //Liest vorhandene Variablen aus dem Json-String und updated diese 
    public void UpdateVariables(string jsonstring)
    {
        JsonUtility.FromJsonOverwrite(jsonstring, this);
    }




    //OPEN PORT
    public void OpenGate()
    {
        streamingIsPossible = true;
        serialPort = new SerialPort(port, baudRate);
        serialPort.Open();
        serialPort.ReadTimeout = 25; //important
        Debug.Log("The Port is open ");
    }


    //READ PORT
    public string ReadSerialPort()
    {
        string data;

        try
        {
            data = serialPort.ReadLine();
            return data;
        }
        catch (TimeoutException)
        {
            return null;
        }
    }


    //CLOSE PORT
    public void CloseGate()
    {
        serialPort.Close();
    }



}
