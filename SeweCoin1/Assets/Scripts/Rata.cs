using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rata : MonoBehaviour {

	public float speedX;
	Transform player, rat;
	enum estado { parado, movimiento };
	estado est;
	bool activar = false;

	void Start () {
		est = estado.parado;
		rat = gameObject.transform;

	}

	void Update () {
		switch (est) {
		case estado.parado:
			if (activar == true) {
				est = estado.movimiento;
			}
			break;
		case estado.movimiento:
			Movement ();
			break;
		}
	}

	void OnBecameVisible (){
		activar = true;
	}

	void Movement(){
		rat.Translate (new Vector2 (speedX * Time.deltaTime, 0f));
	}
	private void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "bloquePatrulla") {
			speedX = -speedX;
		}
	}
}
