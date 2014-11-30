using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {

	//public bool railCastLine; //Railscast line or simple line
	//public float lineDrawVelocity; //Works with railcast disable (railCastLine = slase)
	//public Transform origin;
	//public Transform destination;
	public Material material;
	public Vector3 rayCastDist; //Distance of the raycast and the line when nothing is in it
	public bool reverseX, reverseY, reverseZ;


	private LineRenderer lineRender;
	private Vector3 unitVector = new Vector3(1, 1 ,1);
	private bool enable;
	//private float counter;
	//private float dist;


	// Use this for initialization
	void Start () {
	
		this.lineRender = GetComponent<LineRenderer>();
		this.enable = true;

		if(lineRender == null){

			this.lineRender =  this.gameObject.AddComponent("LineRenderer") as LineRenderer;
			this.lineRender.SetWidth(0.05f, 0.05f);
			this.lineRender.useWorldSpace = false;
			if(lineRender.material != null){

				lineRender.material = this.material;
			}

			throw(new LineRendererException("LineRender NULL a default one will be set"));
		}


	}
	
	// Update is called once per frame
	void Update () {

			this.RenderRayCastLine ();
	}

	//Render the line with the default distance the distance of the hit object if enable (disable position Vector3.zero)
	public void RenderRayCastLine(){

		RaycastHit _hit;

		if (this.enable) {
				
			if(Physics.Raycast(this.transform.position, this.rayCastDist, out _hit))
			{

				if(_hit.collider){

					this.lineRender.SetPosition(1, this.GetRayCastDistCollision(_hit.distance));
				}

			}else{
			
				this.lineRender.SetPosition(1, this.GetRayCastDist());
			}

		}else{

			this.lineRender.SetPosition(1, Vector3.zero);
		}
	
	}

	//Prepare the Vector3 with the distance to renter the raycast(dist multiply unit vector and invert axys if necessery)
	private Vector3 GetRayCastDistCollision(float dist){

		Vector3 v = new Vector3 (0, 0 ,0);

		if(this.rayCastDist.x != 0){

			if(this.reverseX == true){

				v.x = dist * -1;
			}else{

				v.x = dist;
			}

		}
		
		if(this.rayCastDist.y != 0){
			
			if(this.reverseY == true){
				
				v.y = dist * -1;
			}else{
				
				v.y = dist;
			}
		}
		
		if(this.rayCastDist.z != 0){
			
			if(this.reverseZ == true){
				
				v.z = dist * -1;
			}else{
				
				v.z = dist;
			}
		}
		
		return v;
	}

	//Invert the axys if necessery
	private Vector3 GetRayCastDist(){

		if(this.reverseX == true){

			this.rayCastDist.x *= -1; 
		}

		if(this.reverseY == true){
			
			this.rayCastDist.y *= -1; 
		}

		if(this.reverseZ == true){
			
			this.rayCastDist.z *= -1; 
		}

		return this.rayCastDist;
	}

	/*
	public void RenderAnimationLine(){

		dist = Vector3.Distance (this.origin.position, this.destination.position);

		if(this.counter < this.dist){

			this.counter += 0.1f / this.lineDrawVelocity;

			float _x = Mathf.Lerp(0, this.dist, this.counter);

			Vector3 _pointA = origin.position;
			Vector3 _pointB = destination.position;

			//Get the unit vector in the desired direction, multiply by the desired lenght and add the starting point
			Vector3 _pointAlongLine = _x * Vector3.Normalize(_pointB - _pointB) + _pointA;

			lineRender.SetPosition(1, _pointAlongLine);
		}

	}
	*/

	public void DisableDrawLine(){

		this.enable = false;
	}

	public void EnableDrawLine(){

		this.enable = true;
	}
}


public class LineRendererException : UnityException{


	public LineRendererException(string message): base(message)
	{
	}
}