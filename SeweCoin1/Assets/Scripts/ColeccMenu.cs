using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColeccMenu : MonoBehaviour {

	public int numeroDeColeccionable;


	void Start(){
		Colecccionable ();
		}

	public void Colecccionable(){
		bool colecc = GameManager.instance.ActColecc (numeroDeColeccionable);
		if (colecc == true)
			gameObject.SetActive (false);
	}
}
