using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public OnButton onButton;

	void OnTriggerEnter(Collider col){

		onButton.ActionOnTrigger ();
	}

	public virtual void ActionOnTrigger(){

	}
}
