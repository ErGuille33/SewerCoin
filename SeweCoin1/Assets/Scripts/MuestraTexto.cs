using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuestraTexto : MonoBehaviour {

	public GameObject texto;
	public GameObject imagen;

	public void Dentro()
	{
		texto.SetActive (true);
		imagen.SetActive (false);
	}

	public void Fuera()
	{
		texto.SetActive (false);
		imagen.SetActive (true);

	}
}
