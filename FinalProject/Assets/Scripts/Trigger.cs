using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public GameObject actionObject = null;//Player Default

	public bool stateTrigger{
	
		get{

			return state;
		}
	}

	public bool state = false;

	void OnTriggerEnter(Collider col){
		
		if(actionObject != null){
			
			if (col.name == actionObject.name) {
				
				state = true;
			}
		}else{
			
			if (col.gameObject.tag == "Player") {
				
				state = true;
			}
		}

	}

	void OnTriggerExit(Collider col){
		
		if(actionObject != null){
			
			if (col.name == actionObject.name) {
				
				state = false;
			}
		}else{
			
			if (col.gameObject.tag == "Player") {
				
				state = false;
			}
		}
		
	}
}

	

