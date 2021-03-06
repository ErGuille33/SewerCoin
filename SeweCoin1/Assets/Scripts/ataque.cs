﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ataque : MonoBehaviour {

	PlayerController pc;
	Rigidbody2D rb;

	bool atacking = false, atackingAux = false, shooting = false, disparando;//atackingAux sirve para poder poner cd al ataque y no spamearlo.

	public bool saltobomba = false, disparo, sonido;

	public float ataqueTiempAct, tiempoCDAtack, impulsoy = 0f, cañonCD, tiempoDisparo;//tiempo que esta el collider activo
	float tiempoAtaque = 0;

	public Collider2D triggerAtaque;
	public GameObject balaprefab;

	public GameObject spawner;
	Animator playeranim;//para la animacion de ataque de alarico
	AudioSource audiorecarga;

	void Awake () {
		audiorecarga = gameObject.GetComponent<AudioSource> ();
		playeranim = GetComponentInChildren<Animator> ();
		triggerAtaque.enabled = false; 
		pc = GetComponent<PlayerController> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		
		if (Input.GetKeyDown ("j") && !atacking && gameObject.GetComponent <RayCast>().DetectaPlataforma()) {
			playeranim.SetTrigger ("Melee");
			atacking = true;
			atackingAux = true;
			tiempoAtaque = ataqueTiempAct;
			triggerAtaque.enabled = true;


		}

		if (atacking && atackingAux) {
			if (tiempoAtaque > 0)
				tiempoAtaque -= Time.deltaTime;
			else {
				triggerAtaque.enabled = false;
				atackingAux = false;
				Invoke ("DesactivaAtaque", tiempoCDAtack);
			}
		}

		if (Input.GetKeyDown ("k") && !shooting && gameObject.GetComponent <RayCast>().DetectaPlataforma() && disparo) {
			shooting = true;
			sonido = true;
			playeranim.SetTrigger ("Disparo");
			disparando = true;
			Invoke ("CrearBala", tiempoDisparo);

		}

		if (!shooting && sonido) {
			audiorecarga.Play ();
			sonido = false;
		}

 		if (!pc.isJumping && Input.GetKey ("s") && Input.GetKeyDown ("j")) {
			rb.AddForce (new Vector2 (0f, -impulsoy), ForceMode2D.Impulse);
			saltobomba = true;
		}

		if (saltobomba)
			print ("hola");

		if (SceneManager.GetActiveScene ().name == "Boss1" && GameObject.Find ("Jhonny") == null)
			disparo = true;
	}
		
	void DesactivaAtaque (){
		atacking = false;
	}

	void DesactivaCañon(){
		shooting = false;
	}

	public bool SaltoBomba () {
		return saltobomba;
	}

	public bool Atacando(){
		return atackingAux;
	}
	void AnimDisparo(){
		disparando = false;
	}

	public bool Disparando(){
		return disparando;
	}

	void CrearBala(){
		GameObject bala = Instantiate (balaprefab);
		bala.transform.position = spawner.transform.position;
		Invoke ("DesactivaCañon", cañonCD);
		Invoke ("AnimDisparo", 1f);
	}
}
