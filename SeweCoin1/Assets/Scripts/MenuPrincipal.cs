using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour {

	public void Jugar () {
		GameManager.instance.CargaEscena ("Nivel1");
	}

	public void Quitar (){
		Application.Quit();
	}
}
