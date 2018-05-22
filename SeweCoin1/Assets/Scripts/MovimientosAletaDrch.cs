using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosAletaDrch : MonoBehaviour {

	public float velocidad;
	public int numpunetazos;
	int num = 0;
	Rigidbody2D rb;
	bool persecucion = false;

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
			Invoke("PersecucionAleta", 7f);

		}
		else
			PunetazosComienzo ();
	}

	void MovimientoCorrida(){
		gameObject.transform.position = new Vector3 (34f, -0.3f, gameObject.transform.position.z);
		rb.velocity = new Vector3 (-velocidad, 0f, 0f);
		Invoke ("PararDespuesMovCorr", (34f/(2f*velocidad)));
	}

	void PararDespuesMovCorr(){
		PararAleta ();
		Invoke ("QuitarAleta", 3f);
	}

	void QuitarAleta(){
		gameObject.transform.position = new Vector3 (16f, 18f, gameObject.transform.position.z);
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
			gameObject.transform.position = new Vector3 (-3f, -0.5f, gameObject.transform.position.z);
		//rb.velocity = new Vector3 (0f, velocidad, 0f);
		Invoke ("PunioAbajo", 0.25f);
	}

	void PunioAbajo(){
		rb.velocity = new Vector3 (0f, velocidad, 0f);
		Invoke ("PunetazoMov", 7.5f / velocidad);
	}
	void PunetazoMov(){
		rb.velocity = new Vector3 (velocidad, 0f, 0f);
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
