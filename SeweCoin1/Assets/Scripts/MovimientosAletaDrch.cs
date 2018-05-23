using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosAletaDrch : MonoBehaviour {

	public float velocidad;
	public int numpunetazos;
	int num = 0;
	Rigidbody2D rb;
	bool persecucion = false;
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
			Invoke ("MovimientoCorrida", 4f);
			Invoke ("MovimientoCorrida", 12f);
		}
		else if (patron == 1) {
			Invoke("PersecucionAleta", 0f);
			Invoke("PersecucionAleta", 8f);
		}
		else
			PunetazosComienzo ();
	}

	void MovimientoCorrida(){
		gameObject.transform.position = new Vector3 (34f, -0.3f, gameObject.transform.position.z);
		rb.velocity = new Vector3 (-velocidad, 0f, 0f);
		Invoke ("PararDespuesMovCorr", (34f/velocidad));
	}

	void PararDespuesMovCorr(){
		PararAleta ();
		Invoke ("QuitarAleta", 2.5f);
	}

	void QuitarAleta(){
		gameObject.transform.position = new Vector3 (16f, 18f, gameObject.transform.position.z);
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
			gameObject.transform.position = new Vector3 (-3f, -0.5f, gameObject.transform.position.z);
		pos = gameObject.transform.position.x;
		Invoke ("PunioArriba", 0.25f);
	}

	void PunioArriba(){
		if (gameObject.transform.position.y <= 6.9f) {
			transform.position = Vector2.Lerp (gameObject.transform.position, new Vector2 ((pos + (16f / numpunetazos)), 7f), (velocidad / 5f) * Time.deltaTime);
			Invoke ("PunioArriba", 0f);
		} else {
			velocaux = velocidad;
			PunoAbajo ();
		}
	}

	void PunoAbajo(){
		if (gameObject.transform.position.y >= -0.49f) {
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
