using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour {

	public Collider2D ataque;
	public float tiempo;

	public GameObject puerta;

	void OnTriggerEnter2D (Collider2D col) {
		print ("hi");
		if (col == ataque || col.gameObject.tag == "bala") {
			print ("ho");
			Invoke ("Destroy", tiempo);
		}
	}

	void Destroy(){
		Destroy (puerta);
	}
}
