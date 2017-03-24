using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventClickHandler : MonoBehaviour {

    public List<Vector3> locationTo = new List<Vector3>();
    public List<GameObject> objectsToMove = new List<GameObject>();
    public float speed = 2f;

    private bool moving = false;

	void Update () {
        bool finished = false;
        if (moving)
        {
            for (int i = 0; i < locationTo.Count; i++)
            {
                objectsToMove[i].transform.position = Vector3.MoveTowards(objectsToMove[i].transform.position, locationTo[i], speed * Time.deltaTime);
                
            }

        }

    }

    public void OnMouseDown()
    {
        moving = true;
	}


}
