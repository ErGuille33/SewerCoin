using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezIni : MonoBehaviour {

	public void MovPez(){
		if (gameObject.transform.position.y <= -0.44f) {
			gameObject.transform.position = Vector2.Lerp (gameObject.transform.position, new Vector2 (14.77f, -0.45f), (0.7f * Time.deltaTime));
			Invoke ("MovPez", 0f);
		}
	}
}
