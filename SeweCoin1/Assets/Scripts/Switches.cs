using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour {

	public Collider2D ataque;
	public float tiempo;

	public GameObject puerta;

	void OnTriggerEnter2D (Collider2D col) {
		if (col == ataque)
			Invoke ("Destroy", tiempo);
	}

	void Destroy(){
		Destroy (puerta);
	}
}
