using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour {

	public GameObject menu;
	public GameObject opciones;
	public GameObject pausaMenu;
	bool pause = false;

	void Update(){
		if (Input.GetKeyDown ("p") && pause == false) {
			Invoke ("Parar", 0);
			menu.SetActive(false);
			opciones.SetActive (false);
			pausaMenu.SetActive (true);
		} else if (Input.GetKeyDown ("p") && pause == true) {
			Invoke ("Continuar", 0);
			menu.SetActive(true);
		}
	}
	public void VolverMenu(){
		GameManager.instance.CargaEscena ("MenuPrincipal");
	}

	public void Continuar(){
		pause = false;
		Time.timeScale = 1;

	}

	void Parar(){
		pause = true;
		Time.timeScale = 0;
	
	}
}
