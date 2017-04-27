using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandle : MonoBehaviour
{
    public List<int> flagsToFalse = new List<int>();
    public List<int> flagsToTrue = new List<int>();
    public float timeout;

    private bool timing = false;
    private float timeSinceTrigger = 0;

    void Update()
    {

        //after a certain ammount of time unmark the clicked flags
        //to provent bugs arising for click event being flagged before prerequisitis have been met.
        timeSinceTrigger += Time.deltaTime;
        if(timeSinceTrigger >= timeout && timing)
        {
            timeSinceTrigger = 0;
            timing = false;
            foreach (int i in flagsToFalse)
            {
                GlobalVars.setFlag(i, true);
            }
            foreach (int i in flagsToTrue)
            {
                GlobalVars.setFlag(i, false);
            }
        }
    }

    public void OnMouseDown()
    {
        foreach (int i in flagsToFalse)
        {
            GlobalVars.setFlag(i, false);
        }
        foreach (int i in flagsToTrue)
        {
            GlobalVars.setFlag(i, true);
        }
        timing = true;
    }
}
