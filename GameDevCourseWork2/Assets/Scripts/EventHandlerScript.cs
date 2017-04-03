using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandlerScript : MonoBehaviour {

    public List<GameObject> gameObjectsToReference = new List<GameObject>();

    private List<StoryEvent> events = new List<StoryEvent>();
    private float currentTime = 0;
    private List<GlobalVars.MoveObjInfo> currMovingObjs = new List<GlobalVars.MoveObjInfo>();
    private List<GlobalVars.MoveObjInfo> itemsToRemove = new List<GlobalVars.MoveObjInfo>();
    // Use this for initialization
    void Start()
    {
        //StoryEvent newSE = new StoryEvent(List < int > flagsRequiredTrue, List < int > flagsRequiredFalse, float startTimeTrig, float endTimeTrig, List < GameObject > targets, List < Vector3 > destinations, List < float > speeds, List < int > flagTrue, List < int > flagFalse)
        StoryEvent clickBottleDrop = new StoryEvent(new List<int>(new int[] { 0, 1 }), new List<int>(new int[] { 3 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[0] }), new List<Vector3>(new Vector3[] { new Vector3(1f, 0f, 0.45f) }), new List<float>(new float[] { 2f }), new List<int>(new int[] { 2, 3 }), new List<int>(new int[] { 0 }));
        events.Add(clickBottleDrop);
        StoryEvent personMoveToBottle = new StoryEvent(new List<int>(new int[] {}), new List<int>(new int[] { 4 }), 5, 7, new List<GameObject>(new GameObject[] { gameObjectsToReference[1] }), new List<Vector3>(new Vector3[] { new Vector3(1.6f, 1f, 1f) }), new List<float>(new float[] { 2f }), new List<int>(new int[] { 4 }), new List<int>(new int[] {}));
        events.Add(personMoveToBottle);
        StoryEvent personMoveAwayWOBottle = new StoryEvent(new List<int>(new int[] { 2, 4 }), new List<int>(new int[] { 0, 6 }), 8, 10, new List<GameObject>(new GameObject[] { gameObjectsToReference[1] }), new List<Vector3>(new Vector3[] { new Vector3(1.6f, 1f, -5f) }), new List<float>(new float[] { 2f }), new List<int>(new int[] { 6 }), new List<int>(new int[] { }));
        events.Add(personMoveAwayWOBottle);
        StoryEvent personPickUpBottle = new StoryEvent(new List<int>(new int[] { 0, 4 }), new List<int>(new int[] { 5 }), 8, 10, new List<GameObject>(new GameObject[] { gameObjectsToReference[0] }), new List<Vector3>(new Vector3[] { new Vector3(1.5f, 1f, 1f) }), new List<float>(new float[] { 3f }), new List<int>(new int[] { 5 }), new List<int>(new int[] { 2 }));
        events.Add(personPickUpBottle);
        StoryEvent personMoveWithBottle = new StoryEvent(new List<int>(new int[] { 5, 4 }), new List<int>(new int[] { 7 }), 10, 12, new List<GameObject>(new GameObject[] { gameObjectsToReference[0], gameObjectsToReference[1] }), new List<Vector3>(new Vector3[] { new Vector3(5.9f, 1f, 1f), new Vector3(6f, 1f, 1f) }), new List<float>(new float[] { 3f, 3f }), new List<int>(new int[] { 7 }), new List<int>(new int[] { }));
        events.Add(personMoveWithBottle);
        //flag 0 - bottle on table
        //flag 1 - clicked on bottle on table
        //flag 2 - bottle on floor
        //flag 3 - eventClickBottleDrop Complete
        //flag 4 - person moving to bottle
        //flag 5 - person picked up bottle
        //flag 6 - person moving away without bottle
        //flag 7 - person moving away with bottle
        GlobalVars.setFlagArray(new List<bool>(new bool[] { true, false, false, false, false, false, false, false }));


    }


    void Update () {
        currentTime += Time.deltaTime;
        //check for any events triggered
		foreach( StoryEvent e in events)
        {
            if (e.allTriggersMet(currentTime))
            {
                e.updateFlags();
                currMovingObjs.AddRange(e.getActions());
            }
        }

        //moveObjects
        foreach(GlobalVars.MoveObjInfo action in currMovingObjs)
        {
            float step = action.getSpeed() * Time.deltaTime;
            Vector3 newLoc = Vector3.MoveTowards(action.getObject().transform.position, action.getDestination(), step);
            if (newLoc == action.getDestination())
            {
                itemsToRemove.Add(action);
            }
            action.getObject().transform.position = newLoc;
        }
        foreach (GlobalVars.MoveObjInfo action in itemsToRemove)
        {
            currMovingObjs.Remove(action);
        }
        itemsToRemove.Clear();
	}
}
