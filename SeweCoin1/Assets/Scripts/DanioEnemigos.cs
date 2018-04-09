using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigos : MonoBehaviour {

	public int cantDanio;
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player")
			col.gameObject.GetComponent<PlayerController> ().QuitaVida (cantDanio);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player")
			col.gameObject.GetComponent<PlayerController> ().QuitaVida (cantDanio);
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player")
			col.gameObject.GetComponent<PlayerController> ().QuitaVida (cantDanio);
	}
}
