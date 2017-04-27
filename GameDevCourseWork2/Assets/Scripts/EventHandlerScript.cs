using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventHandlerScript : MonoBehaviour {

    public List<GameObject> gameObjectsToReference = new List<GameObject>();
    public int level;

    private List<StoryEvent> events = new List<StoryEvent>();
    private float currentTime = 0;
    private List<GlobalVars.MoveObjInfo> currMovingObjs = new List<GlobalVars.MoveObjInfo>();
    private List<GlobalVars.MoveObjInfo> itemsToRemove = new List<GlobalVars.MoveObjInfo>();

    public bool ending = false;

    private class EndState {

        private List<int> reqTrue;
        private List<int> reqFalse;
        private string endText;
        private bool goodEnding;

        public EndState(List<int> reqTrue, List<int> reqFalse, string endText, bool goodEnding)
        {
            this.reqTrue = reqTrue;
            this.reqFalse = reqFalse;
            this.endText = endText;
            this.goodEnding = goodEnding;
        }

        public bool checkEnded()
        {
            if (reqTrue.Count != 0)
            {
                foreach (int flag in reqTrue)
                {
                    if (!GlobalVars.getFlag(flag))
                    {
                        return false;
                    }
                }
            }

            if (reqFalse.Count != 0)
            {
                foreach (int flag in reqFalse)
                {
                    if (GlobalVars.getFlag(flag))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        public bool rightEnding()
        {
            return goodEnding;
        }

        public string getEndText()
        {
            return endText;
        }

    }

    private List<EndState> endings = new List<EndState>();

    private float timeSinceEndingTripped = 0;

    public string nextLevelName;

    // Use this for initialization
    void Start()
    {
        switch (level)
        {
            case 1:
                genLevel1();
                break;
            case 2:
                genLevel2();
                break;
            case 99:
                genLevelTestEvents();
                break;
        }
    }

    private void genLevel1()
    {

        Vector3 birdDoorLoc = new Vector3(-9.9f, 3.3f, 21.3f);
        Vector3 behindCamera = new Vector3(0, 5, 40);
        Vector3 dadInRoomPos = new Vector3(-3.5f, 2.61f, 19f);
        Vector3 doorTextPos = new Vector3(-11.7f, 4f, 15.9f);
        Vector3 doorOpenPos = new Vector3(-10.5f, 4.5f, 22f);
        Vector3 doorClosePos = new Vector3(-10.5f, 4.5f, 20f);
        Vector3 windowThudPos = new Vector3(16, 4, 16);
        Vector3 heap1MovedPos = new Vector3(1.8f, .2f, 16.6f);
        Vector3 heap2MovedPos = new Vector3(-8f, 0.3f, 23.3f);
        Vector3 heap3MovedPos = new Vector3(5.2f, 0.2f, 23.1f);
        Vector3 windowOPenPos = new Vector3(9.5f, 2.7f, 22.5f);
        Vector3 windowClosePos = new Vector3(10f, 2.77f, 21.3f);
        Vector3 princessBedPos = new Vector3(2.7f, .32f, 20.84f);
        Vector3 princessSideBedPos = new Vector3(8f, 0.3f, 20f);
        Vector3 bedsideTablePos = new Vector3(9f, 2.4f, 16.6f);

        //StoryEvent newSE = new StoryEvent(List < int > flagsRequiredTrue, List < int > flagsRequiredFalse, float startTimeTrig, float endTimeTrig, List < GameObject > targets, List < Vector3 > destinations, List < float > speeds, List < int > flagTrue, List < int > flagFalse)
        StoryEvent birdFlyIn = new StoryEvent(new List<int>(new int[] { 2 }), new List<int>(new int[] { 15 }), 30, 35, new List<GameObject>(new GameObject[] { gameObjectsToReference[9] }), new List<Vector3>(new Vector3[] { birdDoorLoc }), new List<float>(new float[] { 20f }), new List<int>(new int[] { 15 }), new List<int>(new int[] {  }));
        events.Add(birdFlyIn);
        StoryEvent PFindBall = new StoryEvent(new List<int>(new int[] { 8, 3 }), new List<int>(new int[] { 9 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[1] }), new List<Vector3>(new Vector3[] { behindCamera }), new List<float>(new float[] { 10f }), new List<int>(new int[] { 9 }), new List<int>(new int[] { }));
        events.Add(PFindBall);
        StoryEvent PFindBonnet = new StoryEvent(new List<int>(new int[] { 6, 7 }), new List<int>(new int[] { 11 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[2] }), new List<Vector3>(new Vector3[] { behindCamera }), new List<float>(new float[] { 10f }), new List<int>(new int[] { 11 }), new List<int>(new int[] { }));
        events.Add(PFindBonnet);
        StoryEvent PFindClogs = new StoryEvent(new List<int>(new int[] { 12 }), new List<int>(new int[] { 10 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[3] }), new List<Vector3>(new Vector3[] { behindCamera }), new List<float>(new float[] { 10f }), new List<int>(new int[] { 10 }), new List<int>(new int[] { }));
        events.Add(PFindClogs);
        StoryEvent DadEnter = new StoryEvent(new List<int>(new int[] {  }), new List<int>(new int[] { 5, 16 }), 35, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[12] }), new List<Vector3>(new Vector3[] { dadInRoomPos }), new List<float>(new float[] { 7f }), new List<int>(new int[] { 10 }), new List<int>(new int[] { }));
        events.Add(DadEnter);
        StoryEvent DadBreakDoor = new StoryEvent(new List<int>(new int[] { 5 }), new List<int>(new int[] { 14 }), 35, 36, new List<GameObject>(new GameObject[] { gameObjectsToReference[13] }), new List<Vector3>(new Vector3[] { doorTextPos }), new List<float>(new float[] { 5000f }), new List<int>(new int[] { 14 }), new List<int>(new int[] { }));
        events.Add(DadBreakDoor);
        StoryEvent DadOpenDoor = new StoryEvent(new List<int>(new int[] { 5, 14 }), new List<int>(new int[] { 16 }), 40, 41, new List<GameObject>(new GameObject[] { gameObjectsToReference[4], gameObjectsToReference[13] }), new List<Vector3>(new Vector3[] { doorOpenPos, dadInRoomPos }), new List<float>(new float[] { 5000f, 7f }), new List<int>(new int[] { 14 }), new List<int>(new int[] { }));
        events.Add(DadOpenDoor);
        StoryEvent BirdThudWindow = new StoryEvent(new List<int>(new int[] { }), new List<int>(new int[] { 2 }), 30, 31, new List<GameObject>(new GameObject[] { gameObjectsToReference[14]}), new List<Vector3>(new Vector3[] { windowThudPos }), new List<float>(new float[] { 5000f }), new List<int>(new int[] { 3 }), new List<int>(new int[] {  }));
        events.Add(BirdThudWindow);
        StoryEvent BirdThudWindowDisapear = new StoryEvent(new List<int>(new int[] { 13}), new List<int>(new int[] { 2 }), 32, 33, new List<GameObject>(new GameObject[] { gameObjectsToReference[14] }), new List<Vector3>(new Vector3[] { behindCamera }), new List<float>(new float[] { 5000f }), new List<int>(new int[] {  }), new List<int>(new int[] {  }));
        events.Add(BirdThudWindowDisapear);
        StoryEvent Heap1Move = new StoryEvent(new List<int>(new int[] { 17 }), new List<int>(new int[] { 0 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[6] }), new List<Vector3>(new Vector3[] { heap1MovedPos }), new List<float>(new float[] { 7f }), new List<int>(new int[] { 0 }), new List<int>(new int[] { }));
        events.Add(Heap1Move);
        StoryEvent Heap2Move = new StoryEvent(new List<int>(new int[] { 18 }), new List<int>(new int[] { 1 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[7] }), new List<Vector3>(new Vector3[] { heap2MovedPos }), new List<float>(new float[] { 7f }), new List<int>(new int[] { 1 }), new List<int>(new int[] { }));
        events.Add(Heap2Move);
        StoryEvent Heap3Move = new StoryEvent(new List<int>(new int[] { 19 }), new List<int>(new int[] { 6 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[10] }), new List<Vector3>(new Vector3[] { heap3MovedPos }), new List<float>(new float[] { 7f }), new List<int>(new int[] { 6 }), new List<int>(new int[] { }));
        events.Add(Heap3Move);
        StoryEvent OpenWindow = new StoryEvent(new List<int>(new int[] { 20 }), new List<int>(new int[] { 2 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[5] }), new List<Vector3>(new Vector3[] { windowOPenPos }), new List<float>(new float[] { 7f }), new List<int>(new int[] { 2 }), new List<int>(new int[] { 20 }));
        events.Add(OpenWindow);
        StoryEvent CloseWindow = new StoryEvent(new List<int>(new int[] { 20, 2 }), new List<int>(new int[] {  }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[5] }), new List<Vector3>(new Vector3[] { windowClosePos }), new List<float>(new float[] { 7f }), new List<int>(new int[] { }), new List<int>(new int[] { 2, 20 }));
        events.Add(CloseWindow);
        StoryEvent CloseDoor = new StoryEvent(new List<int>(new int[] { 21 }), new List<int>(new int[] { 5 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[4] }), new List<Vector3>(new Vector3[] { doorClosePos }), new List<float>(new float[] { 7f }), new List<int>(new int[] { 5 }), new List<int>(new int[] {21 }));
        events.Add(CloseDoor);
        StoryEvent OpenDoor = new StoryEvent(new List<int>(new int[] { 21, 5 }), new List<int>(new int[] { }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[4] }), new List<Vector3>(new Vector3[] { doorOpenPos }), new List<float>(new float[] { 7f }), new List<int>(new int[] {  }), new List<int>(new int[] { 5, 21 }));
        events.Add(OpenDoor);
        StoryEvent princessMoveToBed = new StoryEvent(new List<int>(new int[] { 22 }), new List<int>(new int[] { }), 5, 6, new List<GameObject>(new GameObject[] { gameObjectsToReference[0] }), new List<Vector3>(new Vector3[] { princessBedPos }), new List<float>(new float[] { 7f }), new List<int>(new int[] { 7 }), new List<int>(new int[] { 22 }));
        events.Add(princessMoveToBed);
        StoryEvent princessMoveToBedSide = new StoryEvent(new List<int>(new int[] { 7 }), new List<int>(new int[] { }), 25, 26, new List<GameObject>(new GameObject[] { gameObjectsToReference[0] }), new List<Vector3>(new Vector3[] { princessSideBedPos }), new List<float>(new float[] { 7f }), new List<int>(new int[] { 8 }), new List<int>(new int[] { 7 }));
        events.Add(princessMoveToBedSide);
        StoryEvent turnOnLight = new StoryEvent(new List<int>(new int[] { 23 }), new List<int>(new int[] { 3 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[8] }), new List<Vector3>(new Vector3[] { bedsideTablePos }), new List<float>(new float[] { 5000f }), new List<int>(new int[] { 3 }), new List<int>(new int[] { 23 }));
        events.Add(turnOnLight);

        EndState dadEnters = new EndState(new List<int>( new int[] { 16 } ), new List<int>(), "Father aks the Princess to do her Chores, No adventures Today. The End", false);
        endings.Add(dadEnters);
        EndState birdEnters = new EndState(new List<int>(new int[] { 15 }), new List<int>(), "Upon finding the dead Bird the princess embarks upon a disection project within the safety of the castle. No adventures today", false);
        endings.Add(birdEnters);
        EndState PrincessLeaves = new EndState(new List<int>(new int[] { 15 }), new List<int>(), "Having Found her ball, the princess decideds to go for a walk with it, what adventures await her?", true);
        endings.Add(PrincessLeaves);


        //flag 0 - heap 1 moved
        //flag 1 - heap 2 moved
        //flag 2 - Window Opened
        //flag 3 - bedside lamp on
        //flag 4 - window opened
        //flag 5 - Door Closed/locked
        //flag 6 - eap 3 moved
        //flag 7 - checking bed
        //flag 8 - checking side of bed
        //flag 9 - princess has ball
        //flag 10 - princess has clogs

        //flag 11 - princess has bonnet
        //flag 12 - checking under bed
        //flag 13 - bird thud
        //flag 14 - dad unlocking door
        //flag 15 - bird hit door
        //flag 16 - dad in room
        //flag 17 - heap 1 click
        //flag 18 - heap 2 clock
        //flag 19 - heap 3 click
        //flag 20 - window clicked

        //flag 21 - door clicked
        //flag 22 - princess at start position
        //flag 23 - lamp clicked
        GlobalVars.setFlagArray(new List<bool>(new bool[] { false, false, false, false, false, false, false, false, false, false, false,
                                                            false, false, false, false, false, false, false, false, false, false,
                                                            false, true, false}));
    }

    private void genLevel2()
    {
        Vector3 loveLoc = new Vector3(55.7f, 29, 33);
        Vector3 ballLoc = new Vector3(-15, 6.3f, 16);
        Vector3 KissLoc = new Vector3(-19, 0, 6);
        Vector3 RemoveLoc = new Vector3(500f, 0f, 0f);

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
        new StoryEvent(new List<int>(new int[] { 3, 6 }), new List<int>(new int[] { 15 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[3], gameObjectsToReference[5], gameObjectsToReference[7], gameObjectsToReference[14] }), new List<Vector3>(new Vector3[] { new Vector3(113f, 40f, 92f), new Vector3(109f, 32f, 85f), new Vector3(102.5f, 37f, 79.5f), RemoveLoc }), new List<float>(new float[] { 15f, 15f, float.MaxValue, float.MaxValue }), new List<int>(new int[] { 21, 15 }), new List<int>(new int[] { 3 }));
        events.Add(dropStalegFrog);
        StoryEvent frogMove1ToCave =
        new StoryEvent(new List<int>(new int[] { 5 }), new List<int>(new int[] {  }), 5, 7, new List<GameObject>(new GameObject[] { gameObjectsToReference[5], gameObjectsToReference[14] }), new List<Vector3>(new Vector3[] { new Vector3(109f, 38f, 85f), loveLoc }), new List<float>(new float[] { 50f, 70f }), new List<int>(new int[] { 6 }), new List<int>(new int[] { 5 }));
        events.Add(frogMove1ToCave);
        StoryEvent frogMove2ToRock1 =
        new StoryEvent(new List<int>(new int[] { 6 }), new List<int>(new int[] { 21 }), 10, 11, new List<GameObject>(new GameObject[] { gameObjectsToReference[5], gameObjectsToReference[14] }), new List<Vector3>(new Vector3[] { new Vector3(90f, 31f, 92f), RemoveLoc }), new List<float>(new float[] { 20f, 5000f }), new List<int>(new int[] { 7 }), new List<int>(new int[] { 6 }));
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
        new StoryEvent(new List<int>(new int[] { 2, 19 }), new List<int>(new int[] { 16, 18, 36 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[2] }), new List<Vector3>(new Vector3[] { new Vector3(-11f, -10f, 10f) }), new List<float>(new float[] { 10f }), new List<int>(new int[] { 18 }), new List<int>(new int[] { 2, 19 }));
        events.Add(padMoveWOFrog);
        StoryEvent padMoveWFrog = 
        new StoryEvent(new List<int>(new int[] { 2, 16, 19 }), new List<int>(new int[] { 18, 36 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[2], gameObjectsToReference[5] }), new List<Vector3>(new Vector3[] { new Vector3(-11f, -10f, 10f), new Vector3(-11f, -10f, 10f) }), new List<float>(new float[] { 10f, 10f }), new List<int>(new int[] { 18 }), new List<int>(new int[] { 2, 19 }));
        events.Add(padMoveWFrog);
        StoryEvent snakeMove1ToCave = 
        new StoryEvent(new List<int>(new int[] { 10 }), new List<int>(new int[] { }), 14, 15, new List<GameObject>(new GameObject[] { gameObjectsToReference[6] }), new List<Vector3>(new Vector3[] { new Vector3(110f, 39f, 85f) }), new List<float>(new float[] { 50f }), new List<int>(new int[] { 11 }), new List<int>(new int[] { 10 }));
        events.Add(snakeMove1ToCave);
        StoryEvent snakeLeave =
        new StoryEvent(new List<int>(new int[] { 11, 18 }), new List<int>(new int[] { 9, 12 }), 20, 21, new List<GameObject>(new GameObject[] { gameObjectsToReference[6] }), new List<Vector3>(new Vector3[] { new Vector3(246f, 39f, 85f) }), new List<float>(new float[] { 50f }), new List<int>(new int[] {  }), new List<int>(new int[] { 11 }));
        events.Add(snakeLeave);

        StoryEvent snakeKillPad =
        new StoryEvent(new List<int>(new int[] { 11, 16 }), new List<int>(new int[] { 12, 18 }), 20, 21, new List<GameObject>(new GameObject[] { gameObjectsToReference[6], gameObjectsToReference[5], gameObjectsToReference[7] }), new List<Vector3>(new Vector3[] { new Vector3(55f, 1.6f, 74f), new Vector3(57f, -10f, 84f), new Vector3(57f, -1f, 71f) }), new List<float>(new float[] { 150f, 20f, 5000f }), new List<int>(new int[] { 36, 21 }), new List<int>(new int[] {}));
        events.Add(snakeKillPad);
        StoryEvent snakeKillRock =
        new StoryEvent(new List<int>(new int[] { 11, 9 }), new List<int>(new int[] {12, 16 }), 20, 21, new List<GameObject>(new GameObject[] { gameObjectsToReference[6], gameObjectsToReference[5], gameObjectsToReference[7] }), new List<Vector3>(new Vector3[] { new Vector3(64f, 10f, 85f), new Vector3(74f, 2f, 92f), new Vector3(68f, 7.5f, 60f) }), new List<float>(new float[] { 150f, 20f, 5000f }), new List<int>(new int[] { 36, 21 }), new List<int>(new int[] { 11 }));
        events.Add(snakeKillRock);

        StoryEvent moveTripRock =
        new StoryEvent(new List<int>(new int[] { 4 }), new List<int>(new int[] { 30 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[4] }), new List<Vector3>(new Vector3[] { new Vector3(-30f, 1f, 26f) }), new List<float>(new float[] { 5f }), new List<int>(new int[] { 30 }), new List<int>(new int[] {  }));
        events.Add(moveTripRock);

        Vector3 PPos0 = new Vector3(-55, 1, 26.3f);
        Vector3 PPos1 = new Vector3(-45, 1, 26.3f);
        Vector3 PPos2 = new Vector3(-39, 1, 26.3f);
        Vector3 PPos3 = new Vector3(-32, 1, 26.3f);
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

        StoryEvent movePtoP3 = 
        new StoryEvent(new List<int>(new int[] { 28 }), new List<int>(new int[] { 30 }), 10, 11, new List<GameObject>(new GameObject[] { gameObjectsToReference[12], gameObjectsToReference[13] }), new List<Vector3>(new Vector3[] { PPos3, PPos3 + ballOffset }), new List<float>(new float[] { 7f, 7f }), new List<int>(new int[] { 29 }), new List<int>(new int[] { 28 }));
        events.Add(movePtoP3);
        StoryEvent throwBall3Up =
        new StoryEvent(new List<int>(new int[] { 29 }), new List<int>(new int[] { }), 12, 13, new List<GameObject>(new GameObject[] { gameObjectsToReference[13] }), new List<Vector3>(new Vector3[] { PPos3 + ballOffset + 24 * Vector3.up }), new List<float>(new float[] { 25f }), new List<int>(new int[] { }), new List<int>(new int[] { }));
        events.Add(throwBall3Up);
        StoryEvent throwBall3down =
        new StoryEvent(new List<int>(new int[] { 29 }), new List<int>(new int[] { }), 13, 14, new List<GameObject>(new GameObject[] { gameObjectsToReference[13] }), new List<Vector3>(new Vector3[] { PPos3 + ballOffset }), new List<float>(new float[] { 25f }), new List<int>(new int[] { }), new List<int>(new int[] { }));
        events.Add(throwBall3down);

        StoryEvent princessLeaveBoring =
        new StoryEvent(new List<int>(new int[] { 29 }), new List<int>(new int[] { }), 14, 15, new List<GameObject>(new GameObject[] { gameObjectsToReference[12], gameObjectsToReference[13] }), new List<Vector3>(new Vector3[] { PPos0, PPos0 + ballOffset }), new List<float>(new float[] { 7f, 7f }), new List<int>(new int[] { 31 }), new List<int>(new int[] { 29 }));
        events.Add(princessLeaveBoring);

        StoryEvent moveTrip =
        new StoryEvent(new List<int>(new int[] { 28, 30 }), new List<int>(new int[] { }), 11, 12, new List<GameObject>(new GameObject[] { gameObjectsToReference[12], gameObjectsToReference[13], gameObjectsToReference[15] }), new List<Vector3>(new Vector3[] { new Vector3(-24f,-1f,26.3f), new Vector3(10f, -11f, 26.3f), ballLoc  }), new List<float>(new float[] { 7f, 10f, float.MaxValue }), new List<int>(new int[] { 32, 33 }), new List<int>(new int[] { 29 }));
        events.Add(moveTrip);

        StoryEvent frogGetBall =
        new StoryEvent(new List<int>(new int[] { 34, 20, 33, 32, 16 }), new List<int>(new int[] { }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[13], gameObjectsToReference[16] }), new List<Vector3>(new Vector3[] { new Vector3(-22f, 2.5f, 26.3f), KissLoc }), new List<float>(new float[] {20f, float.MaxValue }), new List<int>(new int[] {  }), new List<int>(new int[] { 32 }));
        events.Add(frogGetBall);

        StoryEvent princessLeave =
        new StoryEvent(new List<int>(new int[] { 33, 35,16, 20 }), new List<int>(new int[] { 32 }), 0, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[12], gameObjectsToReference[13], gameObjectsToReference[15] }), new List<Vector3>(new Vector3[] { PPos0, PPos0 + ballOffset, RemoveLoc }), new List<float>(new float[] { 10f, 10f, float.MaxValue }), new List<int>(new int[] { }), new List<int>(new int[] { 33 }));
        events.Add(princessLeave);

        StoryEvent princessDrown =
        new StoryEvent(new List<int>(new int[] { 33, 21 }), new List<int>(new int[] { }), 16, float.MaxValue, new List<GameObject>(new GameObject[] { gameObjectsToReference[12], gameObjectsToReference[15] }), new List<Vector3>(new Vector3[] { new Vector3(-9f, -19f, 26.3f), RemoveLoc }), new List<float>(new float[] { 12f, float.MaxValue }), new List<int>(new int[] { 37 }), new List<int>(new int[] { }));
        events.Add(princessDrown);
        

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

        //flag 31 - princess leave boring
        //flag 32 - ball in water
        //flag 33 - princess tripped
        //flag 34 - frog click
        //flag 35 - princess retreived ball
        //flag 36 - snake kill frog
        //flag 37 - princess Drowns

        GlobalVars.setFlagArray(new List<bool>(new bool[] { false, false, false, false, false, true, false, false, false, false, true, 
                                                            false, false, false, true, false, false, false, false, true, false,
                                                            false, false, false, false, false, true, false, false, false, false,
                                                            false, false, false, false, false, false, false, false}));
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

    private EndState theEnding;
    public Text storyText;
    public Button nextBtn;
    public GameObject canvas;

    void Update () {

        if (!ending)
        {

            foreach (EndState end in endings)
            {
                if (end.checkEnded())
                {
                    ending = true;
                    theEnding = end;
                    break;
                }
            }

            currentTime += Time.deltaTime;
            //check for any events triggered
            foreach (StoryEvent e in events)
            {
                if (e.allTriggersMet(currentTime))
                {
                    e.updateFlags();
                    currMovingObjs.AddRange(e.getActions());
                }
            }
        }
        else
        {
            if (timeSinceEndingTripped >= 3)
            {
                storyText.text = theEnding.getEndText();
                canvas.SetActive(true);
                if (theEnding.rightEnding())
                {
                    nextBtn.gameObject.SetActive(true);
                }
                else
                {
                    nextBtn.gameObject.SetActive(false);
                }
            }
            else
            {
                timeSinceEndingTripped += Time.deltaTime;
            }
        }

        //moveObjects
        foreach (GlobalVars.MoveObjInfo action in currMovingObjs)
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

    public void nextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    public void restartLevel()
    {
        canvas.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}