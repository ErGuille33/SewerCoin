using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour {

	public Collider2D ataque;
	public float tiempo;
	public GameObject camara;
	Animator anim;
	public GameObject puerta;

	void Start()
	{
		anim = GetComponentInParent<Animator> ();
		if(gameObject.tag!="Valvula")
		anim.SetBool ("Activo", false);
	}
	void OnTriggerEnter2D (Collider2D col) {
		print ("hi");
		if (col == ataque || col.gameObject.tag == "bala") {
			
			if (gameObject.tag == "Valvula")
			{
				camara.GetComponent<CameraController> ().enabled = false;
				Invoke ("CambiarCamara", 0.5f);

			}
			else anim.SetBool ("Activo", true);
			Invoke ("Destroy", tiempo);

		}
	}

	void Destroy(){
		Destroy (puerta);
		if(gameObject.tag == "Valvula")
			Invoke ("DevolverControlCamara", 1);
	}
	void DevolverControlCamara()
	{
		camara.GetComponent<CameraController> ().enabled = true;	
	}
	void CambiarCamara()
	{
		camara.transform.position =  new Vector3(24.1f,-59.7f,-10f);
	}

}
