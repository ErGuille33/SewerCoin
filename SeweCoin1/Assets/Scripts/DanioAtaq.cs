﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioAtaq : MonoBehaviour {

	public int cantidadDanio;

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.layer == 9 || col.gameObject.tag == "Caja"){
			col.gameObject.GetComponent<VidaEnemigos> ().Quitavida (cantidadDanio);
			gameObject.GetComponent<Collider2D> ().enabled = false;
		}
	}
}
