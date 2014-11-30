using UnityEngine;
using System.Collections;

public class OnButton : Button {

	sealed public override void ActionOnTrigger(){

		this.rigidbody.useGravity = true;
	}
}
