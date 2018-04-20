﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

	public LayerMask capas;
	public float distanciaMuro;
	public float distanciaPlataforma;
	public float angleMuro;
	public float anglePlataforma;




	public bool DetectaMuro(float move){

		RaycastHit2D hit = Physics2D.BoxCast(gameObject.transform.position, new Vector2 (1.66f/2f, 2.5f), angleMuro, new Vector2 (move, 0), distanciaMuro, capas);
		if (hit.collider != null)
			return true;
		else return false;
		}

	public bool DetectaPlataforma(){

		RaycastHit2D hit = Physics2D.BoxCast(gameObject.transform.position, new Vector2 (1.66f/2f, 1f), anglePlataforma, new Vector2 (0, -1), distanciaPlataforma, capas);
		if (hit.collider != null)
			return true;
		else return false;
	}

	}

   
