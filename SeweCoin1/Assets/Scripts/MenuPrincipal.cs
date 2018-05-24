using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour {


	public void Jugar () {
		GameManager.instance.timeractivado = true;
		GameManager.instance.CargaEscena ("CuentaHistoria1");

	}

	public void Quitar (){
		Application.Quit();
	}
		
}
