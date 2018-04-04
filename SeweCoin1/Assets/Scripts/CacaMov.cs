using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacaMov : MonoBehaviour {

	enum estado {parado, movimiento};
	bool izquierda;
	estado est;
	bool activar, algo= true;
	Rigidbody2D rb;
	Transform jugador;

	public GameObject caquitas;
	//public int vida;
	public float impulso, tiempo, separacioncaquitas;

	void Start () {
		jugador = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		est = estado.parado;
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		Cambios ();
		if (jugador.position.x - transform.position.x < 0) {
			izquierda = true;
		} else {
			izquierda = false;
		}
	}

	void OnBecameVisible (){
		activar = true;
	}

	void Movimiento(){
		if (izquierda)
			rb.AddForce (new Vector2 (-impulso, (impulso*2.8f)), ForceMode2D.Impulse);
		else
			rb.AddForce (new Vector2 (impulso, (impulso*2.8f)), ForceMode2D.Impulse);
		algo = true;
	}

	void Cambios(){
		switch (est) {
		case estado.parado:
			if (activar == true) {
				est = estado.movimiento;
			}
			break;
		case estado.movimiento:
			if (algo) {
				algo = false;
				Invoke ("Movimiento", tiempo);
			}
			break;
		}
	}

	public void Dividir(){
		//poscaquitas.position.x = separacioncaquitas;
		GameObject caquita1 = Instantiate (caquitas);
		caquita1.gameObject.transform.position = new Vector2(transform.position.x + separacioncaquitas, transform.position.y);
		GameObject caquita2 = Instantiate (caquitas);
		caquita2.transform.position = new Vector2(transform.position.x - separacioncaquitas, transform.position.y);
	}
}
