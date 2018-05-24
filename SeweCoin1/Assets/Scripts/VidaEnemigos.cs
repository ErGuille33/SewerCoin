using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour {

	public int vida;
	public bool dead;
	public float tiempoparp;
	bool parpadeo = false, ahorita = false;

	void Awake () {
		dead = false;
	}

	public void Quitavida(int daño){
		if (!ahorita){
			ahorita = true;
			Parpadeo ();
			Invoke ("StopIt", tiempoparp);
			vida = vida - daño;
			if (vida <= 0) {
				if (gameObject.tag == "Caca")
					gameObject.GetComponent<CacaMov> ().Dividir ();
				if (gameObject.tag == "Caja")
					gameObject.GetComponent<Cajas> ().Spawn ();
				Destroy (gameObject);
				GameManager.instance.enemigosmatados++;
				dead = true;
			}
		}
	}

	void Parpadeo(){
		if (ahorita) {
			if (parpadeo) {
				if (gameObject.GetComponent<SpriteRenderer> () != null)
					gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				else
					gameObject.GetComponentInChildren<SpriteRenderer> ().enabled = false;
				parpadeo = false;
			} else {
				if (gameObject.GetComponent<SpriteRenderer> () != null)
					gameObject.GetComponent<SpriteRenderer> ().enabled = true;
				else
					gameObject.GetComponentInChildren<SpriteRenderer> ().enabled = true;
				parpadeo = true;
			}
			Invoke ("Parpadeo", 0.25f);
		}
		else 
			if (gameObject.GetComponent<SpriteRenderer> () != null)
				gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			else
				gameObject.GetComponentInChildren<SpriteRenderer> ().enabled = true;
	}

	void StopIt(){
		ahorita = false;
	}
}
