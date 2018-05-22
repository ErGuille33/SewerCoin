using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaBoss2 : MonoBehaviour {

	public Chorros chorros;
	public float tiempochorros;
	public MovimientoAletaIzq aletaizq;
	public MovimientosAletaDrch aletadrch;
	public GameObject cabeza;
	public float tiempoentrepatrones;
	bool chorracos = false, llamada = false;

	public void ComiensoDelPrincipioDelFin(){
		if (!chorracos) {
			chorros.ActivaChorro ();
			chorracos = true;
			Invoke ("PararChorro", tiempochorros);
		} else if(!llamada) {
			if (aletaizq != null && aletadrch != null) {
				llamada = true;
				Invoke ("CambiarLlamada", tiempoentrepatrones);
				Invoke ("LlamadaPatrones", tiempochorros + 2f);
			}
			else if (!(aletaizq == null && aletadrch == null) && (aletaizq == null || aletadrch == null)) {
				llamada = true;
				Invoke ("CambiarLlamada", tiempoentrepatrones);
				Invoke ("LlamadaPatrones", tiempochorros + 2f);
				chorracos = true;
			} else if (aletaizq == null && aletadrch == null) {
				Invoke ("CaeCabeza", 1.5f);
			}
		}

		Invoke ("ComiensoDelPrincipioDelFin", 1f);
	}

	void PararChorro(){
		chorros.DesactivaChorro ();
	}

	void LlamadaPatrones(){
		int patron = Random.Range (0, 4);
		aletaizq.Patron (patron);
		aletadrch.Patron (patron);
	}

	bool pasada = true;
	void CaeCabeza(){
		if(pasada){
			cabeza.transform.position = new Vector3 (15f, 7f, cabeza.transform.position.z);
			pasada = false;
		}
		do{
			cabeza.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 10f, 0f);
		}while(cabeza.transform.position.y >= -0.5f);
	}

	void CambiarLlamada(){
		llamada = false;
	}
}
