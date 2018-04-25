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
	Animator cocoAnim;

	void Awake () {
		est = estado.desactivado;
		sobreCoco = false;
		Trigger.enabled = false;
		preAtaq = tempA;
		posAtaq = tempB;
		cocoAnim = GetComponentInChildren<Animator>();

	}

	void Update () {

		switch (est) {
		case estado.desactivado:
			cocoAnim.SetBool ("Activa2",false);
			Trigger.enabled = false;
			if (sobreCoco == true) {
				if (preAtaq > 0)
					preAtaq -= Time.deltaTime;
				else {
					print ("Activado");
					cocoAnim.SetBool ("Activa2",true);
					Invoke ("ActivaTrigger",0.4f);

				}
			}
			break;
		case estado.activado:
			//cocoAnim.SetTrigger ("Activado");
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
	private void ActivaTrigger()
	{
		est = estado.activado;
	}
}
