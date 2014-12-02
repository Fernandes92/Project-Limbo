using UnityEngine;
using System.Collections;

public class GUIBasic : MonoBehaviour {

	public GameManager gamemanager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		//Principal Box
		GUI.Box (new Rect(Screen.width / 2 - 135, Screen.height / 2 - 150, 300, 350), "");

		//Buttons

		if (GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 - 130, 250, 50), "Start Game")) {
				
			gamemanager.Initialize();
		}

		GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 - 70 , 250, 50), "");
		GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 - 10 , 250, 50), "");
		GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 + 60 , 250, 50), "");

		if (GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 + 120, 250, 50), "Exit")) {
				
			Application.Quit();
		}

	}
}
