using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour {
    

    public float tick;
    float nextTick = 0;
    public int livingNeighbours;
    public GameObject cellPrefab;
    public GameObject[ , ] cells;
    int gridX, gridY = 10;


    // Use this for initialization
    void Start () {

        cells = new GameObject[gridX, gridY];

        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                Vector3 spawnOffset = new Vector3(x, 0, y);
                cells[x , y] = Instantiate(cellPrefab, transform.position + spawnOffset, transform.rotation, transform);

                if (Random.Range(0, 100) > 50)
                {
                    cells[x, y].GetComponent<Cell>().SetState();
                }
            }
        }

        

    }
	// Update is called once per frame
	void Update () {

        if (nextTick > tick){
            for (int x = 0; x < gridX; x++){
                for (int y = 0; y < gridY; y++){
                    Vector3 spawnOffset = new Vector3(x, 0, y);
                    cells[x, y] = Instantiate(cellPrefab, transform.position + spawnOffset, transform.rotation, transform);


                }
            }
            for (int x = 0; x < gridX; x++){
                for (int y = 0; y < gridY; y++) {
                    cells[x, y].GetComponent<Cell>().livingNeighbours = checkNeighbours(x, y);
                }
            }
            for (int y = 0; y < 10; ++y)
            {
                for (int x = 0; x < 10; ++x)
                {
                    cells[x , y].GetComponent<Cell>().alive = IsAlive(x, y);
                }
            }


            Debug.Log("Tick");
            nextTick -= tick;
        }
        nextTick += Time.deltaTime;
    }  

    int checkNeighbours(int x, int y){
        int neighbours = 0;
        for (int i = -1; i <= 1; i++) {       //Kollar ifall objektet är innanför skärmen på X axeln
            if (x + i >= 0 && x + i < gridX) {
                for (int j = -1; j <= 1; j++){   //Kollar ifall objektet är innanför skärmen på Y axeln
                    if (y + j >= 0 && y + j < gridY){
                        if (cells[x + i , y + j].GetComponent<Cell>().alive && !(i == 0 && j == 0)){//Ifall punkten är 0,0 i array. Bli falsk
                            neighbours++;
                        }
                    }
                }
            }
        }
        return neighbours;
    }

    public bool IsAlive(int x, int y)
    {
        if (cells[x , y].GetComponent<Cell>().livingNeighbours < 2)
        {
            return false;
        }
        if (cells[x , y].GetComponent<Cell>().livingNeighbours > 3)
        {
            return false;
        }
        if (cells[x, y].GetComponent<Cell>().livingNeighbours == 0)
        {
            return true;
        }
        //Om cellen inte lever
        if (cells[x , y].GetComponent<Cell>().livingNeighbours == 3 && !cells[x , y].GetComponent<Cell>().alive)
        {
            return true;
        }
        return false;
    }
}
