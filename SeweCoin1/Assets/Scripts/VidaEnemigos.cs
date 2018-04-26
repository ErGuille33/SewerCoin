using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour {

	public int vida;
	public bool dead;

	void Awake () {
		dead = false;
	}

	public void Quitavida(int daño){
		vida = vida - daño;
		if (vida <= 0) {
			if (gameObject.tag == "Caca") 
				gameObject.GetComponent<CacaMov> ().Dividir();
			if (gameObject.tag == "Caja")
				gameObject.GetComponent<Cajas>().Spawn();
			Destroy (gameObject);
			GameManager.instance.enemigosmatados++;
			dead = true;
			print (dead);

		}
	}
}
