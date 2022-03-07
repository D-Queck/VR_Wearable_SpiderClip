using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionActivated : MonoBehaviour
{

    public SerialCom serialcom;
    private Text connText; // connection indicator
    // Start is called before the first frame update
    void Start()
    {
        connText = GetComponent<Text>();
        
    }

    private void Update()
    {
        connText.text = "Connection not activated";

        if (serialcom.Activation == true)
        {
            connText.text = "Connection activated";
        }
    }
}
