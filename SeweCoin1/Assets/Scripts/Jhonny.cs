using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jhonny : MonoBehaviour {

	public GameObject ratas, balas;
	bool disparo = true, izquierda = false;
	int cont = 0;
	Animator animaciones;

	void Start(){
		animaciones = gameObject.GetComponent<Animator> ();
	}

	public void InvocarRatas(){
		animaciones.SetBool ("Atacad", true);
		if (cont != 3) {
			GameObject ratonsitos = Instantiate (ratas);
			ratonsitos.GetComponent<Rata> ().speedX = 2;
			ratonsitos.transform.position = this.gameObject.transform.position;
			Invoke ("InvocarRatas", 2);
			cont++;
		} else {
			animaciones.SetBool ("DisparoA", true);
			animaciones.SetBool ("Atacad", false);
			Disparo ();
		}
	}

	public void Mover1(){
		disparo = false;
		izquierda = true;
		if (transform.position.y <= -3) {
			animaciones.SetBool ("DisparoA", false);
			animaciones.SetBool ("Subir", true);
			gameObject.transform.position += new Vector3 (0f, 0.1f, 0f);
			Invoke ("Mover1", 0.002f);
		} else {
			if (transform.position.x <= 17) {
				animaciones.SetBool ("Subir", false);
				animaciones.SetBool ("Caminar", true);
				transform.position += new Vector3 (0.1f, 0f, 0f);
				Invoke ("Mover1", 0.008f);
			} else {
				disparo = true;
				animaciones.SetBool ("DisparoA", true);
				animaciones.SetBool ("Caminar", false);
			}
		}
	}

	public void Mover2(){
		disparo = false;
		izquierda = false;
		if (transform.position.y <= 3) {
			animaciones.SetBool ("DisparoA", false);
			animaciones.SetBool ("Subir", true);
			transform.position += new Vector3 (0f, 0.1f, 0f);
			Invoke ("Mover2", 0.002f);
		} else {
			if (transform.position.x >= 0) {
				animaciones.SetBool ("Subir", false);
				animaciones.SetBool ("Caminar", true);
				transform.position -= new Vector3 (0.1f, 0f, 0f);
				Invoke ("Mover2", 0.008f);
			} else {
				disparo = true;
				animaciones.SetBool ("DisparoA", true);
				animaciones.SetBool ("Caminar", false);
			}
		}
	}

	void Disparo(){
		if (disparo) {
			Transform balaT = gameObject.transform;
			GameObject bala = Instantiate (balas, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+1.25f), gameObject.transform.rotation);
			//Cambiar negativos
			if (izquierda) {
				bala.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-10f, 0f);
				gameObject.transform.localScale = new Vector2 (-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y);
			} else {
				bala.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10f, 0f);
				gameObject.transform.localScale = new Vector2 (Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y);
			}
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
