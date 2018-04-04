using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour {

	public Collider2D cold;

	private void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			cold.enabled = false;
		}
	}

	private void OnTriggerExit2D (Collider2D col) {
		cold.enabled = true;
	}
		

}
