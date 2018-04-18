using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {

	public GameObject prefabenemigo;
	GameObject enemigo;


	void Awake () {
		enemigo = Instantiate (prefabenemigo);
		enemigo.transform.position = gameObject.transform.position;
	}


	void OnBecameVisible () {
		if (enemigo == null) {
			enemigo = Instantiate (prefabenemigo);
			enemigo.transform.position = gameObject.transform.position;
		}
	}
}
