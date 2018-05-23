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
			gameObject.GetComponent<Text> ().text = "Ultimo tiempo de partida: " + (int) tiempo + " segundos";	
		} else if (gameObject.name == "Enemigos") {
			gameObject.GetComponent<Text> ().text = "Numero de enemigos matados: " + enemigos;	
		}
	}
}
