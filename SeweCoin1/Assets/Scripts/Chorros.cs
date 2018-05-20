using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chorros : MonoBehaviour {

	public float tiempomax, tiempomin;
	public bool activado;
	public GameObject pececillo;
	GameObject[] chorros;

	void Start () {
		chorros = new GameObject[12];
		for (int i = 0; i < chorros.Length; i++)
			chorros [i] = GameObject.Find (i.ToString ());
		Activa ();
		
	}

	public void Activa(){
		float tiempo = Random.Range (tiempomin, tiempomax);
		Invoke ("Activa", tiempo);
		if(activado){
			int i = Random.Range (0, chorros.Length);
			chorros [i].GetComponent<MovimientoChorro> ().Movimiento ();
			pececillo.GetComponent<PececilloMov> ().MovimientoPez (chorros[i].transform.position.x);
		}
	}

	public void ActivaChorro(){
		activado = true;
	}

	public void DesactivaChorro(){
		activado = false;
	}

}
