using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour {

	public int vida;

	public void Quitavida(int daño){
		vida = vida - daño;
		if (vida <= 0) {
			if (gameObject.tag == "Caca") 
				gameObject.GetComponent<CacaMov> ().Dividir();
			Destroy (gameObject);

		}
	}
}
