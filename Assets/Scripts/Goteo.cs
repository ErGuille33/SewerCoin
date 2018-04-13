using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goteo : MonoBehaviour {
	public int spawnTime;
	public GameObject gotaPrefab;
	GameObject gota;
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);

	}
	

	void Spawn () {
		gota = Instantiate (gotaPrefab);
		gota.transform.position = gameObject.transform.position;

	}
}
