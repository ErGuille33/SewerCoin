using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarColecc : MonoBehaviour {

	void Update () {
		Invoke ("Desactivar", 2);
	}

	void Desactivar()
	{
		gameObject.SetActive (false);
	}
}
