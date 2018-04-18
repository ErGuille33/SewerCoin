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
			col.GetComponent<PlayerController> ().CancelaMov(0.9f);
			if (gameObject.transform.position.x > col.gameObject.transform.position.x)
				col.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-knockbackx, knockbacky);
			else
				col.GetComponent<Rigidbody2D> ().velocity = new Vector2 (knockbackx, knockbacky);
			col.gameObject.GetComponent<PlayerController> ().QuitaVida (cantDanio);
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player")
			col.gameObject.GetComponent<PlayerController> ().QuitaVida (cantDanio);
	}
					
}
