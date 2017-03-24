using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVars {
    //array of flags
    private static List<int> flags = new List<int>();
    
    public static void setFlag(int index, int value)
    {
        flags[index] = value;

    }

    public static int getFlag(int index)
    {
        return flags[index];
    }

}
