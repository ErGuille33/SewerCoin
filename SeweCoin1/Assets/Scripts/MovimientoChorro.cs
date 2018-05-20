using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoChorro : MonoBehaviour {

	float velocidad = 15f;
	Rigidbody2D rb;
	Vector3 a;

	void Start(){
		rb = gameObject.GetComponent<Rigidbody2D> ();
		a = gameObject.transform.position;
	}

	void Update(){
		if (gameObject.transform.position.y >= 0)
			Movimiento ();
		if(gameObject.transform.position.y <= -25)
			gameObject.transform.position = a;
	}

	public void Movimiento(){
		rb.velocity = new Vector3 (0f, velocidad, 0f);
		if(gameObject.transform.position.y >=0)
			rb.velocity = new Vector3 (0f, -velocidad, 0f);
	}
}
