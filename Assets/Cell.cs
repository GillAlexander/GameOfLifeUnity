using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    
    public bool alive = false;
    public int livingNeighbours = 0;
    // Use this for initialization

    void Start () {
		
	}
	
    public void SetState(){
        if (alive){
            GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("ALIVE", gameObject);
        }
        else{
            GetComponent<MeshRenderer>().enabled = false;
            Debug.Log("DEAD", gameObject);
        }
    }
}
