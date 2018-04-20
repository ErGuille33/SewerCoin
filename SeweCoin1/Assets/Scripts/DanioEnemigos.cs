using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigos : MonoBehaviour {

	public int cantDanio;
	Rigidbody2D rb;
	public float knockbackx, knockbacky;
	bool golpeado = false;

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<PlayerController> ().QuitaVida (cantDanio);

		}
	}

	void OnTriggerEnter2D(Collider2D col){
		rb = col.GetComponent<Rigidbody2D> ();
		if (col.gameObject.tag == "Player") {
			if (golpeado == false) {
				col.GetComponent<PlayerController> ().CancelaMov (0.4f);
				if (gameObject.transform.position.x > col.gameObject.transform.position.x) {
					col.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-knockbackx, knockbacky);
					golpeado = true;
				} else {
					col.GetComponent<Rigidbody2D> ().velocity = new Vector2 (knockbackx, knockbacky);
					golpeado = true;
				}
				Invoke ("noGolpeado", col.gameObject.GetComponent<PlayerController>().tempInvencible);
				col.gameObject.GetComponent<PlayerController> ().QuitaVida (cantDanio);
			}
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player")
			col.gameObject.GetComponent<PlayerController> ().QuitaVida (cantDanio);
	}
					
	void noGolpeado () {
		golpeado = false;
	}

}
