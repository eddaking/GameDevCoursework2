using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandle : MonoBehaviour
{
    public List<int> flagsToFalse = new List<int>();
    public List<int> flagsToTrue = new List<int>();
    public float timeout;
    public int maxClicks = 1;

    private bool timing = false;
    private int clicks = 0;
    private float timeSinceTrigger = 0;

    void Update()
    {
        if (timing)
        {
            //after a certain ammount of time unmark the clicked flags
            //to provent bugs arising for click event being flagged before prerequisitis have been met.
            timeSinceTrigger += Time.deltaTime;
            if (timeSinceTrigger >= timeout)
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
    }

    public void OnMouseDown()
    {
        if ( clicks >= maxClicks)
        {
            return;
        }

        foreach (int i in flagsToFalse)
        {
            GlobalVars.setFlag(i, false);
        }
        foreach (int i in flagsToTrue)
        {
            GlobalVars.setFlag(i, true);
        }
        timing = true;
        clicks += 1;
    }
}
