using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class MoveClock : MonoBehaviour
{
    //Move Player 
    //public Rigidbody rb;
    //public float moveSpeed = 500f;

    //Get Movement Data
    public Transform clock;
    private Vector3 movementData;
    //string filename = "";
    //private bool startStreaming = false;

    //Distanz ermitteln
    public Text distance;
    private float distanceMagnitude = 0.0f;
    private float distancePreviousMagnitude = 0.0f;
    private Vector3 previousMovementData;
    private float distanceMagnitudeDelta = 0.0f;
    private float gesamteDistanz = 0.0f;

    private void Start()
    {
        //filename = Application.dataPath + "/csvPlayerDataTest.csv";
        previousMovementData = new Vector3();
    }

    private void FixedUpdate()
    {

        //Position Updating
        movementData = clock.position;

        //x.text = clock.position.x.ToString();
        //y.text = clock.position.y.ToString();
        //z.text = clock.position.z.ToString();

        ////Distanz ermitteln
        //distanceMagnitude = movementData.magnitude;
        //distanceMagnitudeDelta = Mathf.Abs(distanceMagnitude) - Mathf.Abs(distancePreviousMagnitude);
        //distancePreviousMagnitude = distanceMagnitude;
        Vector3 movementDeltaVector = movementData - previousMovementData;
        float movementDelta = movementDeltaVector.magnitude;
        gesamteDistanz = gesamteDistanz + Mathf.Abs(movementDelta);
        previousMovementData = movementData;
        distance.text = gesamteDistanz.ToString();

        //Write CSV
        //WriteCSV();  
    }

    //Write Movement Data
    //public void WriteCSV()
    //{
    //    TextWriter tw = new StreamWriter(filename, true);
            
    //    tw.WriteLine(clock.position.x.ToString());
    //    tw.WriteLine(clock.position.y.ToString());
    //    tw.WriteLine(clock.position.z.ToString());
    //    tw.Close();
    //}


}
