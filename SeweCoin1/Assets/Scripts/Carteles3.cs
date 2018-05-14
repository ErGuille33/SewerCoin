using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carteles3 : MonoBehaviour {
	public GameObject cartel;
	public float tiempoDeEspera;
	// Use this forinitialization
	void Start () {
		cartel.SetActive (false);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		cartel.SetActive (true);
		col.gameObject.GetComponent<PlayerController> ().CancelaMov (tiempoDeEspera);
		Destroy (gameObject);
	}
	void OnTriggerExit2D(Collider2D col)
	{
		cartel.SetActive (false);

	}
}
