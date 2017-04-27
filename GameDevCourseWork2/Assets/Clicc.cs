using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicc : MonoBehaviour
{
    Vector3 movePlace = new Vector3(0, 1.9f, 1);
	private bool clicked = false;
    private bool clickable = true;
	private bool paused = false;

    float speed = 85;

    // Use this for initialization
    void Start()
    {
        Rigidbody h = this.gameObject.GetComponent<Rigidbody>();
        h.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
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