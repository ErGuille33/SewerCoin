using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaBoss2 : MonoBehaviour {

	public Chorros chorros;
	public Camera camara;
	public float tiempochorros;
	public MovimientoAletaIzq aletaizq;
	public MovimientosAletaDrch aletadrch;
	public GameObject cabeza;
	public float tiempoentrepatrones;
	public Animator spritepez;
	bool chorracos = false, llamada = false, ealetaizq = true, ealetadrch = true;
	bool pasada = true;
	Camera aux;
	GameObject cartel;

	void Start(){
		aux = camara;
		cartel = GameObject.Find ("TriggerCartel (1)");
	}

	void Update(){
		if (cabeza == null) {
			Destroy(GameObject.Find("Paredes y techos"), 2f);
			if(cartel != null)
				cartel.transform.position = new Vector2 (14.69f, 3.27f);
			camara.fieldOfView = 38f;
			camara.GetComponent<CameraController> ().enabled = true;
			if(spritepez != null)
				Destroy (spritepez.gameObject);
		}
		if (aletadrch == null)
			ealetadrch = false;
		if (aletaizq == null)
			ealetaizq = false;
	}

	public void ComiensoDelPrincipioDelFin(){
		if (!chorracos) {
			chorros.ActivaChorro ();
			chorracos = true;
			Invoke ("PararChorro", tiempochorros);
		} else if(!llamada) {
			if (ealetadrch && ealetaizq) {
				llamada = true;
				Invoke ("CambiarLlamada", tiempoentrepatrones);
				Invoke ("LlamadaPatrones", tiempochorros + 2f);
			}else if (!ealetadrch && !ealetaizq) {
				llamada = true;
				if(spritepez != null)
					spritepez.SetTrigger ("Muerte");
				Invoke ("CaeCabeza", 1.5f);
			}else if ((!ealetadrch || !ealetaizq) && !(ealetaizq && ealetadrch)) {
				llamada = true;
				chorracos = false;
				Invoke ("CambiarLlamada", tiempoentrepatrones);
				Invoke ("LlamadaPatrones", tiempochorros + 2f);
			} 
		}

		Invoke ("ComiensoDelPrincipioDelFin", 0f);
	}

	void PararChorro(){
		chorros.DesactivaChorro ();
	}

	void LlamadaPatrones(){
		int patron = Random.Range (0, 3);
		if(ealetaizq)
			aletaizq.Patron (patron);
		if(ealetadrch)
			aletadrch.Patron (patron);
	}


	void CaeCabeza(){
		if (cabeza != null){
		if (pasada) {
			cabeza.transform.position = new Vector2 (14.77f, 7f);
			pasada = false;
		} 
		if (cabeza.transform.position.y > -1.1f) {
			cabeza.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, -7f, 0f);
			Invoke ("CaeCabeza", 0f);
		} else
			cabeza.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, 0f, 0f);
		}
	}

	void CambiarLlamada(){
		llamada = false;
	}
}
