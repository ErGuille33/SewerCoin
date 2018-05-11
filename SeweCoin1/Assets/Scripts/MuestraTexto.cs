using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
