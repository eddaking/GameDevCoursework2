using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderRockScript : MonoBehaviour {
    public bool charInBox { get; private set; }

    private void Start()
    {
        charInBox = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            charInBox = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        charInBox = false;
    }
}
