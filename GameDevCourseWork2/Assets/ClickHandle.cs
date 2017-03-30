using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandle : MonoBehaviour
{
    public List<int> flagsToFalse = new List<int>();
    public List<int> flagsToTrue = new List<int>();
    //public List<int> requiredTrueFlags = new List<int>();
    //public List<int> requiredFalseFlags = new List<int>();

    public void OnMouseDown()
    {
        //foreach(int i in requiredFalseFlags)
        //{
        //    if (GlobalVars.getFlag(i))
        //    {
        //        return;
        //    }
        //}
        //foreach(int i in requiredTrueFlags)
        //{
        //    if (!GlobalVars.getFlag(i))
        //    {
        //        return;
        //    }
        //}
        foreach (int i in flagsToFalse)
        {
            GlobalVars.setFlag(i, false);
        }
        foreach (int i in flagsToTrue)
        {
            GlobalVars.setFlag(i, true);
        }
    }
}
