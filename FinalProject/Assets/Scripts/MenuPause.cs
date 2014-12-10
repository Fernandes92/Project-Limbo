using UnityEngine;
using System.Collections;

public class MenuPause : MonoBehaviour {

	private bool pauseActive = false;


	void OnGUI(){
		
		if (pauseActive) {
			
			//Principal Box
			GUI.Box (new Rect(Screen.width / 2 - 135, Screen.height / 2 - 150, 300, 350), "");
			
			//Buttons
			if (GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 - 130, 250, 50), "Resume")) {
				
				pauseActive = false;
				Time.timeScale = 1;
			}
			
			
			if (GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 + 120, 250, 50), "Exit")) {
				
				Application.Quit();
			}
		}
		
		
	}
	
	public void PauseActive(){
		
		pauseActive = true;
		Time.timeScale = 0;
	}
}
