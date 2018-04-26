using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColeccMenu : MonoBehaviour {

	public int numeroDeColeccionable;

	public void Colecccionable(){
		bool colecc = GameManager.instance.ActColecc (numeroDeColeccionable);
		if (colecc == true) {
			gameObject.SetActive (false);
		}
	}
}
