using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	bool pause;
	string escenaS;
	public bool timeractivado;
	int salud = 3, vida = 3;
	bool[] coleccionables = new bool [10];
	float timer;
	public int enemigosmatados;

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);


		for (int i = 0; i < 10; i++)		//declarar todos los awards a false
			coleccionables [i] = false;

		timeractivado = false;
		enemigosmatados = 0;

		timer = 0f;
	}

	void Update(){
		/* Activar esta parte cuando haya una escena menu
		if (vida <= 0)
			SceneManager.LoadScene ();*/
		if (salud <= 0)
			salud = 3;
		if (Input.GetKeyDown ("p") && pause == false) {
			pause = true;
			Time.timeScale = 0;
		} else if (Input.GetKeyDown ("p") && pause == true) {
			pause = false;
			Time.timeScale = 1;
		}

		if (timeractivado == true) {
			timer += Time.deltaTime;
		}
		
	}

	public int SumaSalud(int numero){
		salud += numero;
		return salud;
	}

	public int SumaVida(int numero){
		vida += numero;
		return vida;
	}
		
	public void ActivaAward (int e) {
		coleccionables [e] = true;
	}

	public void CargaEscena (string escena){
		SceneManager.LoadScene ("Vida");
		escenaS = escena;
		Invoke ("CargaEscena1", 2);

	}

	void CargaEscena1(){
		SceneManager.LoadScene (escenaS);
	}
}