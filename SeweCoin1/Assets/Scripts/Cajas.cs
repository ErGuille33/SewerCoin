using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajas : MonoBehaviour {

	public GameObject objeto;
	GameObject objetosuelto;

	public void Spawn () {
		objetosuelto = Instantiate (objeto);
		objetosuelto.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y + 1);
	}


}
