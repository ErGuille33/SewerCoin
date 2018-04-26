using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaUI : MonoBehaviour {



	void Update () {
		int vidas = GameManager.instance.SumaVida (0);
		gameObject.GetComponent<Text> ().text = vidas.ToString() + " ";	
	}
}
