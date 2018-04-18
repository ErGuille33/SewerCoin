using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararMovimiento : MonoBehaviour {

	public float tiempoDeEspera;
	public Camera camara;
	public Jhonny jhonny;

	void OnTriggerEnter2D(Collider2D col){
		col.gameObject.GetComponent<PlayerController> ().CancelaMov (tiempoDeEspera);
		col.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, 0f, 0f);
		col.GetComponent<Animator>().SetFloat ("Speed", 0);
		jhonny.CancelaDisparo (tiempoDeEspera);
		camara.GetComponent<CameraController> ().enabled = false;
		camara.transform.position = new Vector3 (11f, -1.5f, -10f);
		camara.GetComponent<Camera> ().fieldOfView = 86.18258f; 
		Destroy (gameObject);
	}
}
