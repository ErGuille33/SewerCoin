using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PararMovimiento : MonoBehaviour {

	public float tiempoDeEspera;
	public Camera camara;
	public Jhonny jhonny;
	public GameObject aletitas;
	public GameObject barrera1;
	public GameObject barrera2;
	public LogicaBoss2 logicaboss;

	void OnTriggerEnter2D(Collider2D col){
		col.gameObject.GetComponent<PlayerController> ().CancelaMov (tiempoDeEspera);
		col.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, 0f, 0f);
		col.GetComponent<Animator> ().SetFloat ("Speed", 0);
		if (SceneManager.GetActiveScene ().name == "Boss1") {
			jhonny.InvocarRatas ();
			camara.GetComponent<CameraController> ().enabled = false;
			camara.transform.position = new Vector3 (11f, -1.5f, -16f);
			camara.GetComponent<Camera> ().fieldOfView = 98f; 
			Destroy (gameObject, 0f);
		} else {
			aletitas.GetComponent<PezIni> ().MovPez ();
			camara.GetComponent<CameraController> ().enabled = false;
			camara.transform.position = new Vector3 (14.61f, -1.26f, -15.7f);
			camara.GetComponent<Camera> ().fieldOfView = 65f; 
			barrera1.transform.position = new Vector2 (31.50f, 3.39f);
			barrera2.transform.position = new Vector3 (-3f, 3.39f);
			Invoke ("StartLogica", tiempoDeEspera);
			Destroy (gameObject, tiempoDeEspera + 0.2f);
		}
	}

	void StartLogica(){
		logicaboss.ComiensoDelPrincipioDelFin ();
	}


}
