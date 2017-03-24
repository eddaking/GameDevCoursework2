using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedObject : MonoBehaviour {

    public struct Effects
    {
        public List<Vector3> locationTo;
        public List<GameObject> objectsToMove;

        public Effects(List<Vector3> locationTo, List<GameObject> objectsToMove)
        {
            this.locationTo = locationTo;
            this.objectsToMove = objectsToMove;
        }
    }

    public List<int> FlagsUsed = new List<int>();
    public float StartTime = 0;
    public List<float> TimeBetweenStartAndIndexFlag = new List<float>();

    public List<GameObject> Objects = new List<GameObject>();
    public List<Vector3> Locations = new List<Vector3>();
    public List<int> SplitAfterX = new List<int>();

    private List<Effects> effects = new List<Effects>();



    //flag[i] is checked at startTime+TimeBetween... = now

    void Start()
    {
        Effects tempEffect;
        List<GameObject> subGOList = new List<GameObject>();
        List<Vector3> subVec3List = new List<Vector3>();
        int j = 0;
        for(int i = 0; i < Objects.Count;)
        {
            subGOList.Add(Objects[i]);
            subVec3List.Add(Locations[i]);
            if (i == SplitAfterX[j])
            {
                tempEffect = new Effects(subVec3List, subGOList);
                j++;
                subGOList = new List<GameObject>();
                subVec3List = new List<Vector3>();
            }
        }
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
