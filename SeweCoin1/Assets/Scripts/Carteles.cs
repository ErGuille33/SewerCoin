using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carteles : MonoBehaviour {
	public GameObject cartel;
	// Use this for initialization
	void Start () {
		cartel.SetActive (false);
	}
	void OnTriggerEnter2D(Collision2D col)
	{
		cartel.SetActive (true);
	}
	void OnTriggerExit2D(Collision2D col)
	{
		cartel.SetActive (false);
	}
}
