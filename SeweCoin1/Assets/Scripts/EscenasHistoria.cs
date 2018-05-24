using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscenasHistoria : MonoBehaviour {

	public float tiempoentrevinietas;
	public GameObject[] tapas;
	public string escena;

	int cont = 0;

	void Start(){
		Sumar ();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape))
			CambiarEscena ();
	}

	public void Sumar(){
		if (cont < tapas.Length) {
			tapas [cont].GetComponent<Image> ().enabled = false;
			cont++;
			Invoke ("Sumar", tiempoentrevinietas);
		} else
			Invoke("CambiarEscena", tiempoentrevinietas + 1f);
	}

	void CambiarEscena(){
		SceneManager.LoadScene (escena);
	}


}
