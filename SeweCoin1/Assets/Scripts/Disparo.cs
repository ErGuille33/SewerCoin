using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour {

	public float velocidad;
	Rigidbody2D rb;
	Transform giro;

	void Awake () {
		giro = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		rb = GetComponent<Rigidbody2D> ();
		if(giro.localScale.x >0)
			rb.velocity = new Vector3 (velocidad, 0f, 0f);
		else
			rb.velocity = new Vector3 (-velocidad, 0f, 0f);
	}
		
	void OnTriggerEnter2D (Collider2D col){
		Invoke ("Destruir", 1f);
	}

	void Destruir(){
		Destroy(this.gameObject);
	}
}
