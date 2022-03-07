using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class heart_rate : MonoBehaviour
{
    private SerialCom serialcom;
    private GameObject serialcomObj;
    public Text displayedtext;
    private float nextActionTime = 0;
    private float period = 0f;
    static public int  oldtrustedbeat = 0;
    // Start is called before the first frame update
    void Start()
    {
        serialcomObj = GameObject.Find("Serial");
        serialcom = serialcomObj.GetComponent<SerialCom>();
      //  displayedtext = this.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            if (serialcom.b !=0 && serialcom.c >=95)
            {
                oldtrustedbeat = serialcom.b;
            }
        }
        if (serialcom.b != 0 && serialcom.c >= 95)
        {

            displayedtext.text = serialcom.b.ToString();
        }
        else displayedtext.text = oldtrustedbeat.ToString();
    }
}
