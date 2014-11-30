using UnityEngine;
using System.Collections;

public class InstructionMovement : MonoBehaviour {

	private string[] Messages = new string[] { 	"Use the arrows to move",
											   	"← Left",
												"→ Right"};
	private bool setText = false;


	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "Player")
			this.setText = true;
	}
	
	void OnTriggerExit(Collider col){
		
		if(col.gameObject.tag == "Player")
			this.setText = false;
	}

	void OnGUI(){

		if (setText) {
				
			GUI.Box (new Rect(Screen.width*0.5f-51f, 170f, 150f, 22f), this.Messages[0]);
			GUI.Box (new Rect(Screen.width*0.5f-51f, 140f, 50f, 22f), this.Messages[1]);
			GUI.Box (new Rect(Screen.width*0.545f, 140f, 50f, 22f), this.Messages[2]);
		}
			

	}
}
