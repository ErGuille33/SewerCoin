using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMov : MonoBehaviour {

	public GameObject jhonny;
	public int mover;

	void OnTriggerEnter2D(Collider2D col){
		jhonny.GetComponent<Jhonny> ().Mover (mover);
		Destroy (gameObject);
	}
}
