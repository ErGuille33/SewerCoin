using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BajaPlataforma : MonoBehaviour {

	public Collider2D cold;
	bool encima;

	private void Update (){
		if (Input.GetKeyDown ("s") && encima) {
			cold.enabled = false;
		}
	}

	private void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player") {
			encima = true;
		}
	}

	private void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.tag == "Player") {
			encima = false;
		}
	}
}
