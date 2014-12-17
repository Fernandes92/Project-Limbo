using UnityEngine;
using System.Collections.Generic;

public class Elevator : MonoBehaviour {


	enum Directions{
		Up,
		Down,
		Right,
		Left
	}

	/*
	public struct Door{

		public GameObject door;
		public BoxCollider boxCollider;
		public MeshRenderer meshRender;


	};*/


	public float movementSpeed;
	public bool verticalElevator = false;
	public GameObject doorRight, doorLeft;
	public bool rightDoorInitialOpen = false, leftDoorInitialOpen = false;
	public bool activeButtonMove = false, needPressButtonToMove = false;
	public Trigger moveButton;
	public Light light;

	private Vector3 direction = Vector3.zero;
	private int directionHorizontal = (int)Directions.Right;
	private int directionVertical = (int)Directions.Up;
	private bool moving = false, canCall = true;
	private List<GameObject> objectsInside = new List<GameObject>();
	//private Door doorRight, doorLeft;

	private Vector3 getDirectionHorizontal{

		get{

			if(this.directionHorizontal == (int)Directions.Right)
				return Vector3.right;
			else
				return Vector3.left;
		}
	}

	private Vector3 getDirectionVertical{
		
		get{
			
			if(this.directionHorizontal == (int)Directions.Up)
				return Vector3.up;
			else
				return Vector3.down;
		}
	}

	private bool isMoveButtonActive{

		get{

			if(activeButtonMove){

				return moveButton.stateTrigger;
			}else{

				return false;
			}
		}
	}

	// Use this for initialization
	void Start () {
	
		/*
		this.doorRight.door        = this.elevatorRightDoor;
		this.doorRight.boxCollider = this.elevatorRightDoor.GetComponent<BoxCollider>();
		this.doorRight.meshRender  = this.elevatorRightDoor.GetComponent<MeshRenderer>();

		this.doorLeft.door        = this.elevatorLeftDoor;
		this.doorLeft.boxCollider = this.elevatorLeftDoor.GetComponent<BoxCollider> ();
		this.doorLeft.meshRender = this.elevatorLeftDoor.GetComponent<MeshRenderer> ();
		*/

		if (this.rightDoorInitialOpen) {
				
			this.OpenDoor("DoorRight");
		}

		if (this.leftDoorInitialOpen) {
			
			this.OpenDoor("DoorLeft");
		}

		if (moveButton == null) {

			activeButtonMove = false;
			needPressButtonToMove = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (this.verticalElevator) {

			if(!needPressButtonToMove){

				if(moving){
					
					
					this.VertivalMove();
				}else if(isMoveButtonActive && canCall){
					
					CloseDoors();
					Move ();
					canCall = false;
					
				}
			}else{

				lightActive(isMoveButtonActive);

				if(moving && isMoveButtonActive){
					
					
					VertivalMove();
				}else{

					moving = false;
				}
			}

				
		}else{

			if(!needPressButtonToMove){
				if(moving){
					
					
					HorizontalMove();
				}else if(isMoveButtonActive && canCall){
					
					CloseDoors();
					Move ();
					canCall = false;
					
				}
			}else{

				lightActive(isMoveButtonActive);


				if(moving && isMoveButtonActive){
					
					
					HorizontalMove();
				}else{

					moving = false;
				}
			}


		}

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.name == "Left" && this.verticalElevator == false) {
				
			this.Stop();
			this.OpenDoor(col.gameObject.tag);
			this.directionHorizontal = (int)Directions.Right;
		}

		if (col.gameObject.name == "Right" && this.verticalElevator == false) {

			this.Stop();
			this.OpenDoor(col.gameObject.tag);
			this.directionHorizontal = (int)Directions.Left;
		}

		if (col.gameObject.name == "Up" && this.verticalElevator == true) {

			this.Stop();
			this.OpenDoor(col.gameObject.tag);
			this.directionHorizontal = (int)Directions.Down;
		}

		if (col.gameObject.name == "Down" && this.verticalElevator == true) {

			this.Stop();
			this.OpenDoor(col.gameObject.tag);
			this.directionHorizontal = (int)Directions.Up;
		}

		if (col.gameObject.tag == "Player") {

			this.objectsInside.Insert(0, col.gameObject);
		}

		if (col.gameObject.name == "Box") {

			this.objectsInside.Add(col.gameObject);
		}
	}

	void OnTriggerExit(Collider col){

		if (col.gameObject.tag == "Player") {
				
			this.objectsInside.RemoveAt(0);
		}

		if (col.gameObject.name == "Box") {
				
			this.objectsInside.RemoveAt(1);
		}
	}

	void OnTriggerStay(Collider col){

		if (col.gameObject.tag == "Player") {
		
			if(Input.GetButton ("Active")){

				this.CloseDoors();
				this.Move();
			}
		}


	}

	private void HorizontalMove(){

		float _speed = this.movementSpeed * Time.deltaTime;

		this.transform.position += this.getDirectionHorizontal *_speed;

		for (int i = 0; i < this.objectsInside.Count; i++) {
				
			this.objectsInside[i].transform.position += this.getDirectionHorizontal *_speed;
		}


	}

	private void VertivalMove(){
		
		float _speed = this.movementSpeed * Time.deltaTime;
		
		this.transform.position += this.getDirectionVertical *_speed;
		
		for (int i = 0; i < this.objectsInside.Count; i++) {
			
			this.objectsInside[i].transform.position += this.getDirectionVertical *_speed;
		}
		
		
	}



	private void Stop(){

		this.moving = false;
	}

	private void Move(){

		this.moving = true;
	}

	private void OpenDoor(string open){

		if (open == "DoorRight") {

			this.doorRight.SetActive(false);
		}

		if (open == "DoorLeft") {

			this.doorLeft.SetActive(false);
		}
	}

	private void CloseDoors(){

		this.doorRight.SetActive(true);

		this.doorLeft.SetActive(true);
	}

	private void lightActive(bool active){

		if(active){
			
			light.enabled = true;
		}else{
			
			light.enabled = false;
		}

	}
}
