using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOfLifeMeny : MonoBehaviour {

    int menyClick = 0;
	// Use this for initialization
	void Start () {
		
	}
    
    public void ExitButton()
    {
        Application.Quit();
    }

    // Update is called once per frame
    public void ButtonPress(string buttonName)
    {
        //menyClick++;

        //if (menyClick >=1)
        //{
        //    SceneManager.LoadScene(Game);
        //}
        print(buttonName);
        switch (buttonName)
        {
            case "Avsluta":
                Application.Quit();
                break;

            case "Brexio!":
                SceneManager.LoadScene("Game");
                break;

            case "Inställningar":
                SceneManager.LoadScene("Settings");
                break;

            default:
                SceneManager.LoadScene("Meny");
                break;
        }

    }
}
