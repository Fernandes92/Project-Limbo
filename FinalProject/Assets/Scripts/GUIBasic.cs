using UnityEngine;
using System.Collections;

public class GUIBasic : MonoBehaviour {

	public GameManager gamemanager;

	private bool principalMenu = false;
	private bool sceneMenu = false;
	private int lastScene = 0;
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

		if(principalMenu){

			if (GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 - 130, 250, 50), "New Game")) {
				
				gamemanager.Load(0);
			}
			
			if(GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 - 70 , 250, 50), "Load")){

				gamemanager.Load(lastScene);
			}
			
			if(GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 - 10 , 250, 50), "Scenes")){

				principalMenu = false;
				sceneMenu = true;
			}

			GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 + 60 , 250, 50), "Credits");
			
			if (GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 + 120, 250, 50), "Exit")) {
				
				Application.Quit();
			}
		}

		if(sceneMenu){


			if (GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 - 130, 250, 50), "0")) {
					
				principalMenu = true;
				sceneMenu = false;
				gamemanager.Load(0);

			}

			if(lastScene >= 1){

				if(GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 - 70 , 250, 50), "1")){
					
					principalMenu = true;
					sceneMenu = false;
					gamemanager.Load(1);
				}
			}


			if(lastScene >= 2){

				if(GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 - 10 , 250, 50), "2")){

					principalMenu = true;
					sceneMenu = false;
					gamemanager.Load(2);
				}
			}

			if(lastScene >=3){

				if(GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 + 60 , 250, 50), "3")){
						
					principalMenu = true;
					sceneMenu = false;
					gamemanager.Load(3);
				}
			}
			

			if(GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 + 120, 250, 50), "Back")){
				
				principalMenu = true;
				sceneMenu = false;

			}
		
				
		}


	}

	public void InitializeGUI(int scene){

		lastScene = scene;
		principalMenu = true;
	}
}
