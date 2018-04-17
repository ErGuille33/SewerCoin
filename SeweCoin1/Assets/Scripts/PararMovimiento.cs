using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararMovimiento : MonoBehaviour {

	public float tiempoDeEspera;
	public Camera camara;

	void OnTriggerEnter2D(Collider2D col){
		col.gameObject.GetComponent<PlayerController> ().CancelaMov (tiempoDeEspera);
		camara.GetComponent<CameraController> ().enabled = false;
		camara.transform.position = new Vector3 (11f, -1.5f, -10f);
		camara.GetComponent<Camera> ().fieldOfView = 86.18258f; 
		Destroy (gameObject);
	}
}
