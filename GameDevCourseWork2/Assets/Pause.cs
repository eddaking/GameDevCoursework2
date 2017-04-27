using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    protected float timeTutStart;
    protected float timeTut1;
    protected float timeTut1delay;
    protected float timeTut2delay;
    protected float timeTut3delay;
    protected float timeTut4delay;
    protected float timeTut2;
    protected float timeTut3;
    protected float timeTut4;
    protected float timeTut5;
    protected GameObject ball_obj;
    protected GameObject rock_obj;
    protected Clicc ball_script;
    protected GameObject panel;
    protected GameObject character;
    protected Text description;

    private bool fallenonce;
    private Vector3 startingPlace;
    private string tut1;
    private string tut2;
    private string tut3;
    private string tut4;
    
    private float timeToStartPart2;
    private float timeToStartPart3;
    private float timeToStartPart4;
    private float timeToStartPart5;
    bool paused = false;
    bool clickable = true;
    bool part4 = false;
    bool part5 = false;
    bool callTheEnd = false;

    float alphaFadeValue = 1f;
    float fadeTime = 3f;

    private UnderRockScript urs;
    private RockClicc rockclicc;

    // Use this for initialization
    void Start()
    {
        timeTutStart = 3f;
        timeTut1delay = timeTutStart + 3.2f;
        timeTut2delay = timeTut1delay + 3.2f;
        timeTut3delay = timeTut2delay + 4f;
        timeTut4delay = timeTut3delay + 3.2f;
        timeTut2 = timeTut1 + 2;
        timeTut3 = timeTut2 + 2;
        timeTut4 = timeTut3 + 2;
        timeTut5 = timeTut4 + 2;
        ball_script = (Clicc)GameObject.Find("ball").GetComponent("Clicc");
        // rock_obj = GameObject.Find ("");
        panel = GameObject.Find("Panel");
        description = GameObject.Find("Description").GetComponent<Text>();
        character = GameObject.Find("Character");
        startingPlace = character.transform.position;
        panel.SetActive(false);
        description.enabled = false;
        tut1 = "Hi, welcome to 'Ascended being simulator 2017', this is a short tutorial to help you understand how to play!";
        tut2 = "In this game you are an omnipotenet being (not really,... but kinda).";
        tut3 = "You get to mess around with certain things within the environment to change the course of events set in place.";
        tut4 = "There are many ways to win, but many ways to lose. Create one of the desired outcomes to complete the level!";
        urs = (UnderRockScript)GameObject.Find("UnderRockPos").GetComponent("UnderRockScript");
        rockclicc = (RockClicc)GameObject.Find("rockObject").GetComponent("RockClicc");

        fallenonce = false;

        NotClickableAllObjects();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!fallenonce)
        {
            FallOffTime();
        }
        else if (!CheckIfBallClicked() && fallenonce)
        {
            ClickBallTime();
        }
        else if (CheckIfBallClicked() && !part4)
        {
            ClickBallAftermath();
        }
        else if (CheckIfCharacterUnderRock() && !part5)
        {

            ClickRockTime();
        }
        else if(part5 && !rockclicc.theend)
        {
            if (rockclicc.getClicked())
            {
                rockclicc.theend = true;
                timeToStartPart5 = Time.timeSinceLevelLoad;
            }
        }else if(rockclicc.theend)
        {
            Debug.Log("Made it to the end");
            End();
        }

    }

    void FallOffTime()
    {
        if (Time.timeSinceLevelLoad >= timeTutStart && Time.timeSinceLevelLoad < timeTut1delay)
        {
            NotClickableAllObjects();
            panel.SetActive(true);
            if (Time.time > timeTutStart + 0.3f)
            {
                PauseAllObjects();
                ShowMessage(tut1);
            }
        }
        else if (Time.timeSinceLevelLoad >= timeTut1delay && Time.timeSinceLevelLoad < timeTut2delay)
        {
            checkCharacterFallenOnce();
            ShowMessage(tut2);
        }
        else if (Time.timeSinceLevelLoad >= timeTut2delay && Time.timeSinceLevelLoad < timeTut3delay)
        {
            checkCharacterFallenOnce();
            ShowMessage(tut3);
        }
        else if (Time.timeSinceLevelLoad >= timeTut3delay && Time.timeSinceLevelLoad < timeTut4delay)
        {
            checkCharacterFallenOnce();
            ShowMessage(tut4);
        }
        else if (Time.timeSinceLevelLoad >= timeTut4delay)
        {
            checkCharacterFallenOnce();
            ShowNoMessage();
            ResumeAllObjects();
        }
    }

    void ClickBallTime()
    {
        float tutpart2_1 = timeToStartPart2 + 2f;
        float tutpart2_2 = tutpart2_1 + 0.1f;
        float tutpart2_3 = tutpart2_2 + 1.9f;


        float tsll = Time.timeSinceLevelLoad;
        if (tsll < tutpart2_2)
        {
            ShowMessage("Time to respawn!");
        }
        else if (tsll > tutpart2_2 && tsll < tutpart2_3)
        {
            PauseAllObjects();
        }
        else if (tsll > tutpart2_3 && tsll < tutpart2_3 + 0.1f)
        {
            ShowMessage("Click on the red object and see what happens");
            IsNowClickableAllObjects();
        }
    }

    void ClickBallAftermath()
    {
        float tutpart3_1 = timeToStartPart3 + 4f;
        float tutpart3_2 = tutpart3_1 + 2f;

        float tsll = Time.timeSinceLevelLoad;
        if (tsll < tutpart3_1)
        {
            ResumeAllObjects();
            ShowMessage("By interacting (clicking) with certain things you will change the course of events.");
        }
        else if (tsll > tutpart3_1)
        {
            ShowMessage("By clicking the ball you made sure demo-kun didn't waltz to his death.");
            part4 = true;
        }
    }

    void ClickRockTime()
    {
        PauseAllObjects();
        float tutpart4_1 = timeToStartPart4 + 2f;
        float tutpart4_2 = tutpart4_1 + 2f;

        float tsll = Time.timeSinceLevelLoad;
        print("tsll: " + tsll);
        print("tutpart4_1: " + tutpart4_1);
        print("tutpart4_2: " + tutpart4_2);

        if (tsll < tutpart4_1)
        {
            ShowMessage("However, if you click the wrong thing it may end badly");
        }
        else if (tsll > tutpart4_1 && tsll < tutpart4_2 + 1f)
        {
            ShowMessage("(click the rock)");
            part5 = true;
        }
    }


    float elapsedTIme = 0;
    float waitTime = 3;

    void End()
    {
        if (elapsedTIme >= waitTime)
        {
            SceneManager.LoadScene("Scenes/Scene0_Tutorial");
        }
        else
        {
            elapsedTIme += Time.deltaTime;
        }

    }

    void checkCharacterFallenOnce()
    {
        if (character.GetComponent<Rigidbody>().velocity.y < -50)
        {
            fallenonce = true;
            Rigidbody c_rigidb = character.GetComponent<Rigidbody>();
            character.transform.position = startingPlace;
            c_rigidb.position = character.transform.position;
            c_rigidb.velocity = Vector3.zero;
            c_rigidb.angularVelocity = Vector3.zero;
            timeToStartPart2 = Time.timeSinceLevelLoad;
            ResumeAllObjects();
        }
    }

    void ShowMessage(string message)
    {
        description.enabled = false;
        description.text = message;
        description.enabled = true;
    }
    void ShowNoMessage()
    {
        description.enabled = false;
    }

    void PauseAllObjects()
    {
        if (!paused)
        {
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
            }
            paused = true;
        }
    }

    void NotClickableAllObjects()
    {
        if (clickable)
        {
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("NotClickable", SendMessageOptions.DontRequireReceiver);
            }
            clickable = false;
        }
    }

    void IsNowClickableAllObjects()
    {
        if (!clickable)
        {
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("IsClickable", SendMessageOptions.DontRequireReceiver);
            }
            clickable = true;
        }
    }

    void ResumeAllObjects()
    {
        if (paused)
        {
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
            }
            paused = false;
        }
    }

    bool CheckIfBallClicked()
    {
        bool clicked = ball_script.getClicked();
        if (clicked == false)
        {
            timeToStartPart3 = Time.timeSinceLevelLoad;
        }
        return clicked;
    }

    bool CheckIfCharacterUnderRock()
    {
        if (urs.charInBox)
        {
            return true;
        }
        else
        {
            timeToStartPart4 = Time.timeSinceLevelLoad;
            return false;
        }
    }
    
    

}
