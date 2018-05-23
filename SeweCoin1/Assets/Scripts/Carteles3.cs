using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carteles3 : MonoBehaviour {
	public GameObject cartel;
	public float tiempoDeEspera;

	void Start () {
		cartel.SetActive (false);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		cartel.SetActive (true);
		col.gameObject.GetComponent<PlayerController> ().CancelaMov (tiempoDeEspera);
		col.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
		col.GetComponent<Animator> ().SetFloat ("Speed", 0);
		Destroy (gameObject);
	}
	void OnTriggerExit2D(Collider2D col)
	{
		cartel.SetActive (false);

	}
}
