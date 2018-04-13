using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BajaTapa : MonoBehaviour {

	public GameObject player;

	ataque ataque;

	public Collider2D cold;

	void Awake() {
		ataque = player.GetComponent<ataque> ();
	}

	private void OnTriggerEnter2D (Collider2D col) {
		Desactivar ();
		Invoke ("Activar", 1);
	}

	void Desactivar () {
		if (ataque.saltobomba) {
			cold.enabled = false;
		}
	}

	void Activar () {
		cold.enabled = true;
	}
}
