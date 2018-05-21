using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jhonny : MonoBehaviour {

	public GameObject ratas, balas;
	bool disparo = true, izquierda = false;
	int cont = 0;

	public void InvocarRatas(){
		if (cont != 3) {
			GameObject ratonsitos = Instantiate (ratas);
			ratonsitos.GetComponent<Rata> ().speedX = 2;
			ratonsitos.transform.position = this.gameObject.transform.position;
			Invoke ("InvocarRatas", 2);
			cont++;
		} else
			Disparo ();
	}

	public void Mover1(){
		disparo = false;
		izquierda = true;
		if (transform.position.y <= -3) {
			gameObject.transform.position += new Vector3 (0f, 0.1f, 0f);
			Invoke ("Mover1", 0.002f);
		} else {
			if (transform.position.x <= 17) {
				transform.position += new Vector3 (0.1f, 0f, 0f);
				Invoke ("Mover1", 0.008f);
				print ("hola");
			} else
				disparo = true;
		}
	}

	public void Mover2(){
		disparo = false;
		izquierda = false;
		if (transform.position.y <= 3) {
			transform.position += new Vector3 (0f, 0.1f, 0f);
			Invoke ("Mover2", 0.002f);
		} else {
			if (transform.position.x >= 0) {
				transform.position -= new Vector3 (0.1f, 0f, 0f);
				Invoke ("Mover2", 0.008f);
			} else
				disparo = true;
		}
	}

	void Disparo(){
		if (disparo) {
			Transform balaT = gameObject.transform;
			GameObject bala = Instantiate (balas, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+1.25f), gameObject.transform.rotation);
			if (izquierda)
				bala.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-10f, 0f);
			else
				bala.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10f, 0f);
		}
		Invoke ("Disparo", 1.5f);
	}

	public void Mover(int parte){
		if (parte == 1) {
			Mover1 ();
		}
		else{
			Mover2();
		}
	}

	public void CancelaDisparo(float tiempo){
		if (disparo) {
			Invoke ("PuedeMov", tiempo-0.5f);
			disparo = false;
		}
	}

	void PuedeMov(){
		Disparo ();
		disparo = true;
	}

}
