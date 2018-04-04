using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocodrilo : MonoBehaviour {

	bool sobreCoco, cocoAux;
	public float tempA, tempB; 
	float preAtaq, posAtaq;
	public Collider2D Trigger;
	public enum estado { desactivado, activado };
	estado est;

	void Awake () {
		est = estado.desactivado;
		sobreCoco = false;
		Trigger.enabled = false;
		preAtaq = tempA;
		posAtaq = tempB;

	}

	void Update () {

		switch (est) {
		case estado.desactivado:
			Trigger.enabled = false;
			if (sobreCoco == true) {
				if (preAtaq > 0)
					preAtaq -= Time.deltaTime;
				else {
					print ("Activado");
					est = estado.activado;
				}
			}
			break;
		case estado.activado:
			Trigger.enabled = true;
			if (posAtaq > 0)
				posAtaq -= Time.deltaTime;
			else {
				print ("Desactivado");
				sobreCoco = false;
				preAtaq = tempA;
				posAtaq = tempB;
				est = estado.desactivado;
			}
			break;

		}
	}

	private void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Player") {
			sobreCoco = true;
		}
	}
}
