#pragma strict


function OnTriggerEnter (obj : Collider) {
	var thedoor = gameObject.FindWithTag("SF_Door");
	thedoor.animation.Play("open");
}

function OnTriggerExit (obj : Collider) {
	var thedoor = gameObject.FindWithTag("SF_Door");
	thedoor.animation.Play("close");
}