using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colectables2 : MonoBehaviour {

	public int awardnumber;
	public GameObject imagen;
	public Text textos;

	static int contador = 0;

	void Start()
	{
		contador = 0;
		if (GameManager.instance.ActColecc (awardnumber))
			Destroy (this);
	}

	void Update()
	{
		if(gameObject.tag == "award")
			iTween.MoveAdd(gameObject, iTween.Hash("y", 0.3f, "easeType", "easeinOutSine", "loopType", "pingPong"));
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			if (this.gameObject.tag == "award") {
				GameManager.instance.ActivaAward (awardnumber);
				contador++;
				imagen.SetActive (true);
				textos.text = " Coleccionables: " + contador + "/5";
			}
			Destroy (gameObject);
		}
	}
}
