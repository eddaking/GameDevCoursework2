using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEvent {



    private List<int> flagsRequiredTrue;
    private List<int> flagsRequiredFalse;
    private float startTimeTrig;
    private float endTimeTrig;
    private List<GlobalVars.MoveObjInfo> actions = new List<GlobalVars.MoveObjInfo>();
    private List<int> flagTrue;
    private List<int> flagFalse;

    public StoryEvent(List<int> flagsRequiredTrue, List<int> flagsRequiredFalse, float startTimeTrig, float endTimeTrig, List<GameObject> targets, List<Vector3> destinations, List<float> speeds, List<int> flagTrue, List<int> flagFalse)
    {
        this.flagsRequiredTrue = flagsRequiredTrue;
        this.flagsRequiredFalse = flagsRequiredFalse;
        this.startTimeTrig = startTimeTrig;
        this.endTimeTrig = endTimeTrig;
        if (targets.Count == destinations.Count && destinations.Count == speeds.Count)
        {
           for( int i = 0; i < targets.Count; i++)
            {
                actions.Add(new GlobalVars.MoveObjInfo(targets[i], destinations[i], speeds[i]));
            }
        }
        else
        {
            Debug.LogError("The arrays of objects to move, destinations and speeds are not the same length, The current lengths are (Obj,Dir,Spd): " + targets.Count + "," + destinations.Count + "," + speeds.Count);
        }
        this.flagTrue = flagTrue;
        this.flagFalse = flagFalse;
    }

    public bool flagsOK()
    {
        if (flagsRequiredTrue.Count != 0)
        {
            foreach (int flag in flagsRequiredTrue)
            {
                if (!GlobalVars.getFlag(flag))
                {
                    return false;
                }
            }
        }

        if (flagsRequiredFalse.Count != 0)
        {
            foreach (int flag in flagsRequiredFalse)
            {
                if (GlobalVars.getFlag(flag))
                {
                    return false;
                }
            }
        }

        return true;
    }
    
    public bool isInTime(float currTime)
    {
        if(startTimeTrig <= currTime && currTime <= endTimeTrig)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public bool allTriggersMet(float currTime)
    {
        if ( isInTime(currTime) && flagsOK())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<GlobalVars.MoveObjInfo> getActions()
    {
        return actions;
    }

    public void updateFlags()
    {
        foreach(int flag in flagTrue)
        {
            GlobalVars.setFlag(flag, true);
        }
        foreach(int flag in flagFalse)
        {
            GlobalVars.setFlag(flag, false);
        }
    }

}