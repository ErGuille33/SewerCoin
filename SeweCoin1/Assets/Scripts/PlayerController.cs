using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	ataque ataque;
	Animator animor;
	Rigidbody2D rb;
	Transform tr;
	public int maxsalud = 3, salud, vidas;
	bool muerto, damaged;
	public float  speed;
	public float jumpHeight;
	float move;
	public bool isJumping = false;


	void Awake () {
		salud = maxsalud;
		vidas = 3;
		muerto = false;
	}


	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		tr = gameObject.GetComponent<Transform> ();
		ataque = GetComponent<ataque> ();
		animor = GetComponent<Animator> ();
	}

	void Update () {
		MovimientoLateral ();
		Salto ();
		if (salud <= 0)
			Death ();
	}

	void MovimientoLateral(){
			if (Input.GetKey("d")){
				move = Input.GetAxis ("Horizontal");
				tr.Translate( new Vector2 (speed*Time.deltaTime, 0f));
				animor.SetFloat ("Speed", move);
				tr.localScale = new Vector2 (Mathf.Abs (tr.localScale.x), tr.localScale.y);

			}
			if (Input.GetKey("a")){
				move = - Input.GetAxis ("Horizontal");
				tr.Translate( new Vector2 (-speed*Time.deltaTime, 0f));
				animor.SetFloat ("Speed", move);
				tr.localScale = new Vector2 (-Mathf.Abs (tr.localScale.x), tr.localScale.y);
			}
			if (!Input.GetKey ("a") && !Input.GetKey ("d")) {
				move = 0;
				animor.SetFloat ("Speed", move);
			}
	}

	void Salto(){
		if (Input.GetKeyDown ("space") && !isJumping)
		{ 
			rb.AddForce(Vector2.up * jumpHeight);
			animor.SetTrigger ("Saltar");
			isJumping = true;
		}
	}
		
	private void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "cocodrilo") {
			salud = 0;
		}
	}
	private void OnCollisionEnter2D (Collision2D col) {
		
		if (col.gameObject.tag == "ground") {				//comprobar si está en suelo
			isJumping = false;
			noSaltoBomba ();
		}

		if (col.gameObject.tag == "platform") {				//comprobar si esta en suelo
			isJumping = false;
			noSaltoBomba ();
		}

		if ((col.gameObject.tag == "enemigo"||col.gameObject.tag == "smoke" || col.gameObject.tag == "Caca") && !damaged) {
			salud--;
			damaged = true;
			print (salud);
		}
		if (col.gameObject.tag == "gota") {
			Destroy (col.gameObject);
			if (!damaged) {
				salud--;
				damaged = true;
				print (salud);
			}
		}

		if (damaged) {										//espera 3 segs para que se pueda danhar otra vez
			Invoke ("Danhado", 3);
		}
		if (col.gameObject.tag == "instaKill") {
			salud = 0;
		}
	}

	private void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.tag == "platform") {				//comprobar si esta en suelo
			isJumping = true;
		}
	}

	void Danhado () {
		damaged = false;
	}

	void noSaltoBomba () {
		ataque.saltobomba = false;
	}

	void Death () {
		print ("muerto");
		SceneManager.LoadScene ("Pruebas");
	}

		


}
