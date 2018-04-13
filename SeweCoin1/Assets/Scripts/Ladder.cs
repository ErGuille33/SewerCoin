using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {
	bool agarrado= false;
	public float speed = 6;
	void Start () {
		
	}
	

	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player" && (Input.GetKey (KeyCode.W)||Input.GetKey (KeyCode.S)))
			agarrado = true;
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player")
		agarrado = false;
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Player" && Input.GetKey (KeyCode.W)) {
			col.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed);
		} else if (col.tag == "Player" && Input.GetKey (KeyCode.S)) {
			col.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -speed);		
		} else if(col.tag == "Player"  && agarrado==true ) col.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,0.59f);

	}
}
