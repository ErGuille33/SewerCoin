using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigos : MonoBehaviour {

	public int cantDanio, knockbackx, knockbacky;
	Rigidbody2D rb;
	public GameObject player;

	void Awake () {
		rb = player.GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<PlayerController> ().QuitaVida (cantDanio);

		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (gameObject.transform.position.x > col.gameObject.transform.position.x)
				rb.AddForce (new Vector2 (-knockbackx, knockbacky), ForceMode2D.Impulse);
			else
				rb.AddForce (new Vector2 (knockbackx, knockbacky), ForceMode2D.Impulse);
			col.gameObject.GetComponent<PlayerController> ().QuitaVida (cantDanio);
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player")
			col.gameObject.GetComponent<PlayerController> ().QuitaVida (cantDanio);
	}
}
