using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    
    public bool alive;
    public int livingNeighbours = 0;
    // Use this for initialization

    void Start () {
		
	}
	
    public void SetState()
    {
        if (alive)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
