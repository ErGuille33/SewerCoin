using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murciélago : MonoBehaviour {
	public float speedX, speedY, mdistance, movVertical, m;
	private float offsetX, offsetY;
	Rigidbody rb;
	Transform player, bat;
	GameObject go;
	public enum estado { parado, cayendo, mov, movimiento };
	estado est;
	Animator anim;

	void Start () {
		est = estado.parado;
		go = GameObject.FindGameObjectWithTag ("Player");
		player = go.transform;
		bat = gameObject.transform;
		m = 0;
		anim = GetComponent<Animator> ();
		anim.SetBool ("Activo",false);
	}

	// Update is called once per frame
	void Update () {

		switch (est) { 
		case estado.parado:
			if( DetectaJugador()){
				est = estado.cayendo;
			}
			break;
		case estado.cayendo:
			anim.SetBool ("Activo",true);
			if (m < movVertical)
			{
				bat.Translate(new Vector2(0, -0.2f));
				m = m + 0.2f;
			}
			else
			{
				est = estado.mov;
			}
			break;
		case estado.mov:
			iTween.MoveAdd(gameObject, iTween.Hash("y", speedY, "easeType", "easeinOutSine", "loopType", "pingPong"));
			est = estado.movimiento;
			break;
		case estado.movimiento:
			Movement();
			break;
		}
		if (speedX < 0)
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;
		else
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;

	}
	void Movement(){
		bat.Translate(new Vector2(speedX * Time.deltaTime, 0f));        

	}
	bool DetectaJugador() {
		bool detected;
		offsetX = Mathf.Abs(player.position.x - bat.position.x);
		offsetY = player.position.y- bat.position.y;
		if (offsetX <= mdistance && offsetY < 0)
		{
			detected = true;
		}
		else { detected = false; }

		return detected;
	}
	void OnCollisionEnter2D (Collision2D col) 
	{
		if (col.gameObject.layer == 0) {
			speedX = -speedX;
		}
	}
}
