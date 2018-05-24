using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAletaIzq : MonoBehaviour {

	public float velocidad;
	Rigidbody2D rb;
	public int numpunetazos;
	bool persecucion = false;
	int num = 0;
	float pos, velocaux;

	void Start(){
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		if (persecucion)
			gameObject.transform.position = new Vector3(GameObject.FindWithTag ("Player").transform.position.x, 7f, gameObject.transform.position.z);
	}

	public void Patron(int patron){
		if (patron == 0) {
			Invoke ("MovimientoCorrida", 0f);
			Invoke ("MovimientoCorrida", 7f);
		}
		else if (patron == 1) {
			Invoke ("PersecucionAleta", 4f);
			Invoke ("PersecucionAleta", 12f);
		}
		else
			PunetazosComienzo ();
	}

	void MovimientoCorrida(){
		gameObject.transform.position = new Vector3 (-5f, -1f, gameObject.transform.position.z);
		rb.velocity = new Vector3 (velocidad, 0f, 0f);
		Invoke ("PararDespuesMovCorr", (34f/velocidad));
	}

	void PararDespuesMovCorr(){
		rb.velocity = new Vector3 (0f, 0f, 0f);
		Invoke ("QuitarAleta", 2f);
	}

	void QuitarAleta(){
		gameObject.transform.position = new Vector3 (12f, 18f, gameObject.transform.position.z);
	}

	void PersecucionAleta(){
		persecucion = true;
		num = numpunetazos;
		velocaux = velocidad;
		Invoke ("PunoAbajo", 1.5f);
	}

	void PararAleta(){
		rb.velocity = new Vector3 (0f, 0f, 0f);
	}

	void PunetazosComienzo(){
		if(num == 0)
			gameObject.transform.position = new Vector3 (32f, -1f, gameObject.transform.position.z);
		pos = gameObject.transform.position.x;
		Invoke ("PunioArriba", 0.25f);
	}

	void PunioArriba(){
		if (gameObject.transform.position.y <= 6.9f) {
			transform.position = Vector2.Lerp (gameObject.transform.position, new Vector2 ((pos - (16f / numpunetazos)), 7f), (velocidad / 5f) * Time.deltaTime);
			Invoke ("PunioArriba", 0f);
		} else {
			velocaux = velocidad;
			PunoAbajo ();
		}
	}

	void PunoAbajo(){
		if (gameObject.transform.position.y >= -0.99f) {
			persecucion = false;
			velocaux += 0.01f; 
			rb.velocity = new Vector3 (0f, -velocaux, 0f);
			Invoke ("PunoAbajo", 0f);
		} else {
			num++;
			PararAleta();
			if (num < numpunetazos)
				Invoke ("PunetazosComienzo", 0f);
			else {
				Invoke ("QuitarAleta", (7.5f / velocidad) + 2.5f);
				num = 0;
			}
		}
	}
}
