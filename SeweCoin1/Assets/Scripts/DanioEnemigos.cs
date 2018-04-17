using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigos : MonoBehaviour {

	public int cantDanio;
	Rigidbody2D rb;
	public float knockbackx, knockbacky;


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<PlayerController> ().QuitaVida (cantDanio);

		}
	}

	void OnTriggerEnter2D(Collider2D col){
		rb = col.GetComponent<Rigidbody2D> ();
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
