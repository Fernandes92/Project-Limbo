using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	private DataBase db;

	void Start(){

		db = new DataBase ();
	}

	void OnTriggerEnter(Collider col){

		if(col.gameObject.tag == "Player"){

			string _aux;
			_aux = this.gameObject.name.Substring(this.gameObject.name.Length - 1);
 
			db.Insert(int.Parse(_aux));
		}
	}

}
