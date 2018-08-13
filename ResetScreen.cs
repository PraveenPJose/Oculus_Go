using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResetScreen : MonoBehaviour {


    public bool recenterButton;
    public Text count;

    void Start ()
    {
        recenterButton = true;
    }


    public void Recenter()
    {
        if(recenterButton)
        {
            recenterButton = false;
            DisplayText("3");
            StartCoroutine(RecenterCountdown());
        }
    }
  
    IEnumerator RecenterCountdown()
    {
        int seconds = 3;
        while (seconds > 0)
        {
            DisplayText(seconds.ToString());
            yield return new WaitForSeconds(1);
            seconds--;
        }
        OVRManager.display.RecenterPose();
        DisplayText("Reset");
        recenterButton = true;
    }

    void DisplayText(string s)
    {
        if(count!=null)
        {
            count.text = "" + s;
        }
    }

}
