using UnityEngine;
using System.Collections;

public class InstructionInteractActive : MonoBehaviour {

	private string[] Messages = new string[] { 	"Use left control to interact and E to active objects"};
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
			
			GUI.Box (new Rect(Screen.width*0.5f-51f, 170f, 300f, 22f), this.Messages[0]);
			//GUI.Box (new Rect(Screen.width*0.5f-51f, 140f, 50f, 22f), this.Messages[1]);
			//GUI.Box (new Rect(Screen.width*0.545f, 140f, 50f, 22f), this.Messages[2]);
		}
		
		
	}
}
