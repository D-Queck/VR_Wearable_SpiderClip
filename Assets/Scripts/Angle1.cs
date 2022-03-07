using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angle1 : MonoBehaviour
{
    private SerialCom serialcom;
    private GameObject serialcomObj;
    private Text displayedtext;
    // Start is called before the first frame update
    void Start()
    {
        serialcomObj = GameObject.Find("Serial");
        serialcom = serialcomObj.GetComponent<SerialCom>();

        displayedtext = this.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        displayedtext.text = serialcom.ax.ToString();
    }
}
