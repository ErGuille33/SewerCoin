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
	bool damaged, parar = false;
	public string escena;
	public float  speed, jumpHeight, tempInvencible;
	float move;
	public bool isJumping = false;
	bool facingRight = true;



	void Awake () {
		salud = maxsalud;
		vidas = 3;
	}


	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		tr = gameObject.GetComponent<Transform> ();
		ataque = GetComponent<ataque> ();
		animor = GetComponent<Animator> ();
	}

	void Update () {
		animor.SetBool ("Saltando", !gameObject.GetComponent <RayCast> ().DetectaPlataforma ());
		animor.SetFloat ("Salto", rb.velocity.y);
		if (gameObject.GetComponent<ataque> ().Atacando ())
			rb.velocity = new Vector2 (0, rb.velocity.y);
		animor.SetInteger ("Vida", salud);
		if (!parar) {
			MovimientoLateral ();
			Salto ();
		}
		if (salud <= 0)
			Death ();
	}
		

	void MovimientoLateral(){
		float move = Input.GetAxis("Horizontal");
		if (!gameObject.GetComponent <RayCast>().DetectaMuro(move) && !gameObject.GetComponent<ataque> ().Atacando () && !gameObject.GetComponent<ataque> ().Disparando ())
			rb.velocity = new Vector2(move*speed, rb.velocity.y);

		animor.SetFloat("Speed", Mathf.Abs(move));


		if (move > 0 && !facingRight)
			Flip();
		else if (move < 0 && facingRight)
			Flip();
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}

	void Salto(){
		if (gameObject.GetComponent <RayCast> ().DetectaPlataforma ()) {
			isJumping = true;
			if (Input.GetKeyDown ("space")) { 
				rb.AddForce (Vector2.up * jumpHeight);
			}
		} else
			isJumping = false;
	}
	private void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "LifeUp") {
			vidas = GameManager.instance.SumaVida(1);
		}

		if (col.gameObject.tag == "HealthUp") {
			if (salud != maxsalud) salud = GameManager.instance.SumaSalud(1);
			print (salud);
		}

		if (col.gameObject.layer == 0) {				//comprobar si esta en suelo
			noSaltoBomba ();
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
		SceneManager.LoadScene (escena);
	}

	public void QuitaVida(int cantDanio){
		if (!damaged || cantDanio >= 3) {
			salud = GameManager.instance.SumaSalud (-cantDanio); 
			damaged = true;
			print (salud);
			Invoke ("Danhado", tempInvencible);				//espera 3 segundos antes de volver a hacer daño
		}
	}

	public void CancelaMov(float tiempo){
		if (!parar) {
			Invoke ("PuedeMov", tiempo);
			parar = true;
		}
	}

	public void PuedeMov(){
		if (parar)
			parar = false;
	}


}
