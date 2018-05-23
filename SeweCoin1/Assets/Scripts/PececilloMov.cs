using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PececilloMov : MonoBehaviour {

	Rigidbody2D rb;

	void Start(){
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update(){
		if(gameObject.transform.position.y >= -7f)
			rb.velocity = new Vector3 (0f, -10f, 0f);
		if (gameObject.transform.position.y <= -10f)
			rb.velocity = new Vector3 (0f, 0f, 0f);
	}

	public void MovimientoPez(float x){
		gameObject.transform.position = new Vector3 (x, -9f, gameObject.transform.position.z);
		rb.velocity = new Vector3 (0f, 10f, 0f);

	}
}
