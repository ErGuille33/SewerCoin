using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoAtaque : MonoBehaviour {

	public int cantidadDaño;

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "enemigo" || col.gameObject.tag == "Caca"){
			col.gameObject.GetComponent<VidaEnemigos> ().Quitavida (cantidadDaño);
		}
	}
}
