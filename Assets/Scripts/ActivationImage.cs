using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivationImage : MonoBehaviour
{
    private SerialCom serialcom;
    private GameObject serialcomObj;
    public Sprite ConnectedPicture;
    public Sprite NotConnected;
    private Image image;
    private bool turnoffbool = true;


    // Start is called before the first frame update
    void Start()
    {
        serialcomObj = GameObject.Find("Serial");
        serialcom = serialcomObj.GetComponent<SerialCom>();

        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (serialcom.Activation == true && turnoffbool)
        {
            image.overrideSprite = ConnectedPicture;
            turnoffbool = false;
        }
        else
        {
            image.overrideSprite = NotConnected;
            turnoffbool = true;
        }
    }
}
