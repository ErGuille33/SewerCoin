using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAletaIzq : MonoBehaviour {

	public float velocidad;
	Rigidbody2D rb;
	public int numpunetazos;
	bool persecucion = false;
	int num = 0;

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
			Invoke ("MovimientoCorrida", 8f);
		}
		else if (patron == 1) {
			Invoke ("PersecucionAleta", 3.5f);
			Invoke ("PersecucionAleta", 10.5f);
		}
		else
			PunetazosComienzo ();
	}

	void MovimientoCorrida(){
		gameObject.transform.position = new Vector3 (-5f, -0.3f, gameObject.transform.position.z);
		rb.velocity = new Vector3 (velocidad, 0f, 0f);
		Invoke ("PararDespuesMovCorr", (34f/(2f*velocidad)));
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
		Invoke ("AtacaDesPersc", 1.5f);
	}

	void AtacaDesPersc(){
		persecucion = false;
		rb.velocity = new Vector3 (0f, -velocidad/2f, 0f);
		Invoke ("PararAleta", 15f / velocidad);
		Invoke ("QuitarAleta", 30f / velocidad);
	}

	void PararAleta(){
		rb.velocity = new Vector3 (0f, 0f, 0f);
	}

	void PunetazosComienzo(){
		if(num == 0)
			gameObject.transform.position = new Vector3 (32f, -0.5f, gameObject.transform.position.z);
	//	rb.velocity = new Vector3 (0f, velocidad, 0f);
		Invoke ("PunioAbajo", 0.25f);
	}

	void PunioAbajo(){
		rb.velocity = new Vector3 (0f, velocidad, 0f);
		Invoke ("PunetazoMov", 7.5f / velocidad);
	}

	void PunetazoMov(){
		rb.velocity = new Vector3 (-velocidad, 0f, 0f);
		Invoke ("PunoAbajo", 16f/(velocidad*numpunetazos));
	}

	void PunoAbajo(){
		rb.velocity = new Vector3 (0f, -velocidad, 0f);
		num++;
		Invoke ("PararAleta", 7.5f/velocidad);
		if (num < numpunetazos)
			Invoke ("PunetazosComienzo", (7.5f / velocidad) + 0.5f);
		else {
			Invoke ("QuitarAleta", (7.5f / velocidad) + 3f);
			num = 0;
		}
	}
}
