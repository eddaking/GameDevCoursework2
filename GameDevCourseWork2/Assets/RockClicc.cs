using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockClicc : MonoBehaviour
{
    Vector3 movePlace;
    private bool clicked = false;
    private bool clickable = true;
    private bool paused = false;
    public bool theend { get; set; }

    float speed = 6;
    float secondToEnd = 3;

    // Use this for initialization
    void Start()
    {
        movePlace = new Vector3(transform.position.x, 2.4f, transform.position.z);
        theend = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (theend)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, movePlace, step);
        }
    }


    void OnMouseDown()
    {
        if (clickable)
        {
            clicked = true;
        }
    }
  

    void OnPauseGame()
    {
        paused = true;
    }

    void OnResumeGame()
    {
        paused = false;
    }

    void NotClickable()
    {
        clickable = false;
    }

    void IsClickable()
    {
        clickable = true;
    }

    public bool getClicked()
    {
        return clicked;
    }


}