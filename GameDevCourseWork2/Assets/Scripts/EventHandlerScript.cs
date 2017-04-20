using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EventHandlerScript : MonoBehaviour {

    public List<GameObject> gameObjectsToReference = new List<GameObject>();
    public int level;

    private List<StoryEvent> events = new List<StoryEvent>();
    private float currentTime = 0;
    private List<GlobalVars.MoveObjInfo> currMovingObjs = new List<GlobalVars.MoveObjInfo>();
    private List<GlobalVars.MoveObjInfo> itemsToRemove = new List<GlobalVars.MoveObjInfo>();

    // Use this for initialization
    void Start()
    {
        switch (level)
        {
            case 2:
                genLevel2();
                break;
            case 99:
                genLevelTestEvents();
                break;
        }
    }

    private void genLevel2()
    {
        //events
        //StoryEvent newSE = new StoryEvent(List < int > flagsRequiredTrue, List < int > flagsRequiredFalse, float startTimeTrig, float endTimeTrig, List < GameObject > targets, List < Vector3 > destinations, List < float > speeds, List < int > flagTrue, List < int > flagFalse)
        StoryEvent frogArmorDrop = 
        new StoryEvent(new List<int>(new int[] { 1 }), new List<int>(new int[] { 17 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[9] }), new List<Vector3>(new Vector3[] { new Vector3(-21.3f, 2.7f, 29.25f) }), new List<float>(new float[] { 10f }), new List<int>(new int[] { 17 }), new List<int>(new int[] { 1 }));
        events.Add(frogArmorDrop);
        StoryEvent dropStalegEmpty = 
        new StoryEvent(new List<int>(new int[] { 3 }), new List<int>(new int[] { 6, 11, 15 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[3] }), new List<Vector3>(new Vector3[] { new Vector3(113f, 40f, 92f) }), new List<float>(new float[] { 15f }), new List<int>(new int[] { 15 }), new List<int>(new int[] { 3 }));
        events.Add(dropStalegEmpty);
        StoryEvent dropStalegSnake = 
        new StoryEvent(new List<int>(new int[] { 3, 11 }), new List<int>(new int[] { 15 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[3], gameObjectsToReference[6], gameObjectsToReference[7] }), new List<Vector3>(new Vector3[] { new Vector3(113f, 40f, 92f), new Vector3(110f, 36.5f, 85f), new Vector3(102.5f, 37f, 79.5f) }), new List<float>(new float[] { 15f, 15f, float.MaxValue }), new List<int>(new int[] { 12, 15 }), new List<int>(new int[] { 3 }));
        events.Add(dropStalegSnake);
        StoryEvent dropStalegFrog = 
        new StoryEvent(new List<int>(new int[] { 3, 6 }), new List<int>(new int[] { 15 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[3], gameObjectsToReference[5], gameObjectsToReference[7] }), new List<Vector3>(new Vector3[] { new Vector3(113f, 40f, 92f), new Vector3(109f, 32f, 85f), new Vector3(102.5f, 37f, 79.5f) }), new List<float>(new float[] { 15f, 15f, float.MaxValue }), new List<int>(new int[] { 21, 15 }), new List<int>(new int[] { 3 }));
        events.Add(dropStalegFrog);
        StoryEvent frogMove1ToCave =
        new StoryEvent(new List<int>(new int[] { 5 }), new List<int>(new int[] {  }), 5, 7, new List<GameObject>(new GameObject[] { gameObjectsToReference[5] }), new List<Vector3>(new Vector3[] { new Vector3(109f, 38f, 85f) }), new List<float>(new float[] { 50f }), new List<int>(new int[] { 6 }), new List<int>(new int[] { 5 }));
        events.Add(frogMove1ToCave);
        StoryEvent frogMove2ToRock1 =
        new StoryEvent(new List<int>(new int[] { 6 }), new List<int>(new int[] { 21 }), 10, 11, new List<GameObject>(new GameObject[] { gameObjectsToReference[5] }), new List<Vector3>(new Vector3[] { new Vector3(90f, 31f, 92f) }), new List<float>(new float[] { 20f }), new List<int>(new int[] { 7 }), new List<int>(new int[] { 6 }));
        events.Add(frogMove2ToRock1);
        StoryEvent frogMove3ToRock2 = 
        new StoryEvent(new List<int>(new int[] { 7 }), new List<int>(new int[] { }), 11, 12, new List<GameObject>(new GameObject[] { gameObjectsToReference[5] }), new List<Vector3>(new Vector3[] { new Vector3(79f, 19f, 92f) }), new List<float>(new float[] { 20f }), new List<int>(new int[] { 8 }), new List<int>(new int[] { 7 }));
        events.Add(frogMove3ToRock2);
        StoryEvent frogMove4ToRock3 = 
        new StoryEvent(new List<int>(new int[] { 8 }), new List<int>(new int[] { }), 12, 13, new List<GameObject>(new GameObject[] { gameObjectsToReference[5] }), new List<Vector3>(new Vector3[] { new Vector3(69f, 6f, 92f) }), new List<float>(new float[] { 20f }), new List<int>(new int[] { 9 }), new List<int>(new int[] { 8 }));
        events.Add(frogMove4ToRock3);
        StoryEvent frogMove5ToPad = 
        new StoryEvent(new List<int>(new int[] { 9, 19 }), new List<int>(new int[] { 18 }), 13, 14, new List<GameObject>(new GameObject[] { gameObjectsToReference[5] }), new List<Vector3>(new Vector3[] { new Vector3(57f, 0f, 84f) }), new List<float>(new float[] { 20f }), new List<int>(new int[] { 16 }), new List<int>(new int[] { 9 }));
        events.Add(frogMove5ToPad);
        StoryEvent padMoveWOFrog = 
        new StoryEvent(new List<int>(new int[] { 2, 19 }), new List<int>(new int[] { 16, 18 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[2] }), new List<Vector3>(new Vector3[] { new Vector3(-11f, -10f, 10f) }), new List<float>(new float[] { 7f }), new List<int>(new int[] { 18 }), new List<int>(new int[] { 2, 19 }));
        events.Add(padMoveWOFrog);
        StoryEvent padMoveWFrog = 
        new StoryEvent(new List<int>(new int[] { 2, 16, 19 }), new List<int>(new int[] { 18 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[2], gameObjectsToReference[5] }), new List<Vector3>(new Vector3[] { new Vector3(-11f, -10f, 10f), new Vector3(-11f, -10f, 10f) }), new List<float>(new float[] { 7f, 7f }), new List<int>(new int[] { 18 }), new List<int>(new int[] { 2, 19 }));
        events.Add(padMoveWFrog);
        StoryEvent snakeMove1ToCave = 
        new StoryEvent(new List<int>(new int[] { 10 }), new List<int>(new int[] { }), 14, 15, new List<GameObject>(new GameObject[] { gameObjectsToReference[6] }), new List<Vector3>(new Vector3[] { new Vector3(110f, 39f, 85f) }), new List<float>(new float[] { 50f }), new List<int>(new int[] { 11 }), new List<int>(new int[] { 10 }));
        events.Add(snakeMove1ToCave);
        StoryEvent snakeLeave =
        new StoryEvent(new List<int>(new int[] { 11, 18 }), new List<int>(new int[] { 9, 12 }), 20, 21, new List<GameObject>(new GameObject[] { gameObjectsToReference[6] }), new List<Vector3>(new Vector3[] { new Vector3(246f, 39f, 85f) }), new List<float>(new float[] { 50f }), new List<int>(new int[] {  }), new List<int>(new int[] { 11 }));
        events.Add(snakeLeave);
        StoryEvent moveTripRock =
        new StoryEvent(new List<int>(new int[] { 4 }), new List<int>(new int[] { 30 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[4] }), new List<Vector3>(new Vector3[] { new Vector3(-30f, 1f, 26f) }), new List<float>(new float[] { 5f }), new List<int>(new int[] { 30 }), new List<int>(new int[] {  }));
        events.Add(moveTripRock);
        Vector3 PPos1 = new Vector3(-45, 1, 26.3f);
        Vector3 PPos2 = new Vector3(-45, 1, 26.3f);
        Vector3 PPos3 = new Vector3(-45, 1, 26.3f);
        Vector3 ballOffset = new Vector3(2.5f, 3.6f, 0);

        StoryEvent movePtoP1 = 
        new StoryEvent(new List<int>(new int[] { 26 }), new List<int>(new int[] {  }), 0, 2, new List<GameObject>(new GameObject[] { gameObjectsToReference[12], gameObjectsToReference[13] }), new List<Vector3>(new Vector3[] { PPos1, PPos1+ballOffset }), new List<float>(new float[] { 7f, 7f }), new List<int>(new int[] { 27 }), new List<int>(new int[] { 26 }));
        events.Add(movePtoP1);
        StoryEvent throwBall1Up =
        new StoryEvent(new List<int>(new int[] { 27 }), new List<int>(new int[] { }), 2, 3, new List<GameObject>(new GameObject[] { gameObjectsToReference[13] }), new List<Vector3>(new Vector3[] { PPos1 + ballOffset + 19 * Vector3.up }), new List<float>(new float[] { 20f }), new List<int>(new int[] {  }), new List<int>(new int[] {  }));
        events.Add(throwBall1Up);
        StoryEvent throwBall1down =
        new StoryEvent(new List<int>(new int[] { 27 }), new List<int>(new int[] { }), 3, 4, new List<GameObject>(new GameObject[] { gameObjectsToReference[13] }), new List<Vector3>(new Vector3[] { PPos1 + ballOffset }), new List<float>(new float[] { 20f }), new List<int>(new int[] { }), new List<int>(new int[] { }));
        events.Add(throwBall1down);

        StoryEvent movePtoP2 =
        new StoryEvent(new List<int>(new int[] { 27 }), new List<int>(new int[] { }), 5, 6, new List<GameObject>(new GameObject[] { gameObjectsToReference[12], gameObjectsToReference[13] }), new List<Vector3>(new Vector3[] { PPos2, PPos2 + ballOffset }), new List<float>(new float[] { 7f, 7f }), new List<int>(new int[] { 28 }), new List<int>(new int[] { 27 }));
        events.Add(movePtoP2);
        StoryEvent throwBall2Up =
        new StoryEvent(new List<int>(new int[] { 28 }), new List<int>(new int[] { }), 7, 8, new List<GameObject>(new GameObject[] { gameObjectsToReference[13] }), new List<Vector3>(new Vector3[] { PPos2 + ballOffset + 24 * Vector3.up }), new List<float>(new float[] { 25f }), new List<int>(new int[] { }), new List<int>(new int[] { }));
        events.Add(throwBall2Up);
        StoryEvent throwBall2down =
        new StoryEvent(new List<int>(new int[] { 28 }), new List<int>(new int[] { }), 8, 9, new List<GameObject>(new GameObject[] { gameObjectsToReference[13] }), new List<Vector3>(new Vector3[] { PPos2 + ballOffset }), new List<float>(new float[] { 25f }), new List<int>(new int[] { }), new List<int>(new int[] { }));
        events.Add(throwBall2down);


        //flag 0 - click branch
        //flag 1 - click armour type
        //flag 2 - click lilypad
        //flag 3 - click stalegmite
        //flag 4 - click rock
        //flag 5 - frog@pos0
        //flag 6 - frog@pos1
        //flag 7 - frog@pos2
        //flag 8 - frog@pos3
        //flag 9 - frog@pos4
        //flag 10 - snake@pos0

        //flag 11 - snake@pos1
        //flag 12 - snake dead
        //flag 13 - squirel@pos0
        //flag 14 - squirel@pos1
        //flag 15 - staleg droped
        //flag 16 - frog on pad
        //flag 17 - frog armour floor
        //flag 18 - pad moving
        //flag 19 - pad@start
        //flag 20 - pad@end

        //flag 21 - frog dead
        //flag 22 - snake@pos2
        //flag 23 - snake@pos3
        //flag 24 - snake@pos4
        //flag 25 - snake on pad
        //flag 26 - princess@pos0
        //flag 27 - princess@pos1
        //flag 28 - princess@pos2
        //flag 29 - princess@pos3
        //flag 30 - rockintrippos
        //
        GlobalVars.setFlagArray(new List<bool>(new bool[] { false, false, false, false, false, true, false, false, false, false, true, 
                                                            false, false, false, true, false, false, false, false, true, false,
                                                            false, false, false, false, false, true, false, false, false, false}));
    }

    private void genLevelTestEvents()
    {
        
        //StoryEvent newSE = new StoryEvent(List < int > flagsRequiredTrue, List < int > flagsRequiredFalse, float startTimeTrig, float endTimeTrig, List < GameObject > targets, List < Vector3 > destinations, List < float > speeds, List < int > flagTrue, List < int > flagFalse)
        StoryEvent clickBottleDrop = new StoryEvent(new List<int>(new int[] { 0, 1 }), new List<int>(new int[] { 3 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[0] }), new List<Vector3>(new Vector3[] { new Vector3(1f, 0f, 0.45f) }), new List<float>(new float[] { 2f }), new List<int>(new int[] { 2, 3 }), new List<int>(new int[] { 0 }));
        events.Add(clickBottleDrop);
        StoryEvent personMoveToBottle = new StoryEvent(new List<int>(new int[] { }), new List<int>(new int[] { 4 }), 5, 7, new List<GameObject>(new GameObject[] { gameObjectsToReference[1] }), new List<Vector3>(new Vector3[] { new Vector3(1.6f, 1f, 1f) }), new List<float>(new float[] { 2f }), new List<int>(new int[] { 4 }), new List<int>(new int[] { }));
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

    private void readFile(string fileLoc)
    { 
        string line;
        StreamReader myStreamReader = new StreamReader(fileLoc);

        using (myStreamReader)
        {
            while(true)
            {
                line = myStreamReader.ReadLine();

                if (line != null)
                {
                    string[] entries = line.Split(',');
                    if (entries.Length > 0) { }
                    //core read in functionality
                }
                else
                {
                    break;
                }
            }
            myStreamReader.Close();
        }
    }

}