using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calories : MonoBehaviour
{
    private SerialCom serialcom;
    private GameObject serialcomObj;
    public Text displayedtext;
    private bool startMessureCal = false;

    //user Gender
     public bool male = false;
     public bool female = false;

    //user parameter
    int oxygen = 0;
    double bpm = 0;
    public double age = 20;
    public double weight = 50f;

    //calories berechnen
    private double caloriesPur = 0.0f;
    public double caloriesAusgabe = 0f;

    private float nextActionTime = 0;
    private float period = 10f;

    private void Start()
    {
        serialcomObj = GameObject.Find("Serial");
        serialcom = serialcomObj.GetComponent<SerialCom>();
       // displayedtext = this.GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        bpm = heart_rate.oldtrustedbeat;
        oxygen = serialcom.o;
      
        if(bpm != 0)
        {
            startMessureCal = true;
        }

        if (Time.time > nextActionTime && startMessureCal)
        { 
            nextActionTime += period;
            if (male == true && female == false)
            {
                caloriesAusgabe += CaloriesCalculationMale();

            }
            if (male == false && female == true)
            {
                caloriesAusgabe += CaloriesCalculationFemale();
            }

            //else
            //{
            //    Debug.Log("no gender elected!!!");
            //}
            displayedtext.text = caloriesAusgabe.ToString();
            

         //   Debug.Log(caloriesAusgabe);
        }


    }

    private double CaloriesCalculationMale()
    {
        caloriesPur = (-95.7735 + (0.271 * age) + (0.394 * weight * 2.20462262185) + (0.404 * oxygen) + (0.634 * bpm)) / 4.184;
        return (0.166666f) * caloriesPur;

    }

    private double CaloriesCalculationFemale()
    {
        caloriesPur= (-59.3954 + (0.274 * age) + (0.103 * weight* 2.20462262185) + (0.380 * oxygen) + (0.450 * bpm)) / 4.184;
        Debug.Log(caloriesPur);
        return (0.166666f) * caloriesPur;
    }
}