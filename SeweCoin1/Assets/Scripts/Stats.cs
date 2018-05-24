using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

	int enemigos;
	float tiempo;

	void Start () {
		GameManager.instance.LeeStats (out tiempo, out enemigos);
	}
	
	void Update () {
		if (gameObject.name == "Tiempo") {
			gameObject.GetComponent<Text> ().text = "Tiempo de partida: " + (int) tiempo + " s";	
		} else if (gameObject.name == "Enemigos") {
			gameObject.GetComponent<Text> ().text = "Enemigos matados: " + enemigos;	
		}
	}
}
