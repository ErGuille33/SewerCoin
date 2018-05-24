using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	ataque ataque;
	Animator animor;
	Rigidbody2D rb;
	Transform tr;
	public int maxsalud = 3, salud, vidas;
	bool damaged, parar = false;
	public string escena;
	public float  speed, tempInvencible, slideForce;
    public float jumpHeight = 11.5f;
    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 2f;
    float move;
	public bool isJumping = false;
	bool facingRight = true;
    bool slide = false;
	GameObject vidasUIF;

	void Awake () {
		Time.timeScale = 1;
		salud = maxsalud;
		vidasUIF = GameObject.Find("VidasUIF");
		Invoke ("DesactivaVidaUI", 2);
		CancelaMov (2f);
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
        else if (!slide && rb.velocity.y >= 0.5)
            Sliding();

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

    void Salto()
    {
        //Al pulsar el botón del saltar aumenta la velocidad en la "y" del jugador
        if (gameObject.GetComponent<RayCast>().DetectaPlataforma())
        {
            isJumping = true;
            if (Input.GetButtonDown("Jump"))
            rb.velocity = Vector2.up * jumpHeight;
        }
        else
            isJumping = false;

        //Si el jugador esta subiendo sin pulsar el boton de salto aumenta lentamente
        //la gravedad en "y" hasta que empieza a caer y la gravedad en "y" aumenta más
        //rapidamente
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1f) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1f) * Time.deltaTime;
    }


    //Realiza el deslizamiento del jugador dando un pequeño impulso
    //hacia arriba si choca con la pared
    void Sliding()
    {
        rb.velocity = Vector2.up * slideForce;
        slide = true;
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
		salud = 3;
		vidas = GameManager.instance.SumaVida (-1);
		animor.SetFloat ("Speed", 0);
		GameManager.instance.CargaEscena (escena);
		vidasUIF.SetActive (true);
		GameManager.instance.enemigosmatados = 0;
	}

	public void QuitaVida(int cantDanio){
		if (!damaged || cantDanio >= 3) {
			salud = GameManager.instance.SumaSalud (-cantDanio); 
			damaged = true;
			print (salud);
			Invoke ("Danhado", tempInvencible);				//espera 3 segundos antes de volver a hacer daño
		}
	}

	void DesactivaVidaUI(){
		vidasUIF.SetActive (false);
		vidas = GameManager.instance.SumaVida (0);
		salud = GameManager.instance.SumaSalud (0);
		if (vidas <= 0) {
			SceneManager.LoadScene ("MenuPrincipal");
			vidas = GameManager.instance.SumaVida (3);
			salud = 3;
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

	void CambiarEscena(){
		salud = maxsalud;
		GameManager.instance.CargaEscena (escena);
	}
}
