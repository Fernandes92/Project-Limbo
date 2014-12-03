using UnityEngine;
using System.Collections;

public class EndTalk : MonoBehaviour {

	bool displayText = false;

	void OnTriggerEnter(Collider col){

		if(col.gameObject.tag == "Player")
			displayText = true;
	}

	void OnTriggerExit(Collider col){
		
		if(col.gameObject.tag == "Player")
			displayText = false;
	}


	void OnGUI(){
		
		if (displayText) {
				
			GUI.Box (new Rect(Screen.width / 2 - 135, Screen.height / 2 - 150, 300, 60), "My space ship \n Finaly I can go home \n I dont wanna see that humans anymore");
		}
			
		

		
	}
}
