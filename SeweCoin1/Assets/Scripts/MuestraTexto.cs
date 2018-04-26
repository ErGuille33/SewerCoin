using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuestraTexto : MonoBehaviour {

	public GameObject texto;

	public void Dentro()
	{
		texto.SetActive (true);
	}

	public void Fuera()
	{
		texto.SetActive (false);
	}
}
