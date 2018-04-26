using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEscena : MonoBehaviour {

	public string escena;

	void OnTriggerEnter2D(){
		GameManager.instance.CargaEscena (escena);
	}
}
