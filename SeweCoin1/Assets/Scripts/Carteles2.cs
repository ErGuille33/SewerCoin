using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carteles2 : MonoBehaviour {
	public GameObject cartel;
	// Use this forinitialization
	void Start () {
		cartel.SetActive (false);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		cartel.SetActive (true);
	}
	void OnTriggerExit2D(Collider2D col)
	{
		cartel.SetActive (false);
		Destroy (gameObject);
	}
}
