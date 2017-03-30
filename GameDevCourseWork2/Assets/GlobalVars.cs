using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVars {

    public struct MoveObjInfo
    {
        private GameObject target;
        private Vector3 destination;
        private float speed;

        public MoveObjInfo(GameObject target, Vector3 destination, float speed)
        {
            this.target = target;
            this.destination = destination;
            this.speed = speed;
        }

        public GameObject getObject()
        {
            return target;
        }

        public Vector3 getDestination()
        {
            return destination;
        }

        public float getSpeed()
        {
            return speed;
        }


    }

    //array of flags
    private static List<bool> flags = new List<bool>();
    
    public static void setFlagArray(List<bool> newArray)
    {
        flags = newArray;
    }

    public static void setFlag(int index, bool value)
    {
        flags[index] = value;

    }

    public static bool getFlag(int index)
    {
        return flags[index];
    }

}
