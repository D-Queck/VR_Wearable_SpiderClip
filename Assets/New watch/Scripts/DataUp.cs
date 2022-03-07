using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataUp : MonoBehaviour
{
    public GameObject uhrzeitText;
    public GameObject datumText;

    [SerializeField] [Range(0f, 5f)] float lerpTime;

    //Vektor Startwert = 90
    private Vector3 dataAngleUp = new Vector3(-45f,0f,0f);
    private Vector3 dataAngleDown = new Vector3(45f, 0f, 0f);

    bool upOrDown;

    private void Awake()
    {
        upOrDown = true;
    }

    public void animateData()
    {
        if(upOrDown == true)
        {
            datumText.transform.Rotate(dataAngleUp);
            uhrzeitText.transform.Rotate(dataAngleUp);
            upOrDown = !upOrDown;
        }
        else if(upOrDown == false)
        {
            datumText.transform.Rotate(dataAngleDown);
            uhrzeitText.transform.Rotate(dataAngleDown);
            upOrDown = !upOrDown;
        }
    }
    
}
