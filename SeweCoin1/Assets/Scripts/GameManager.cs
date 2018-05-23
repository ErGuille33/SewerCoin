using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	bool pause;
	public bool timeractivado;
	int salud = 3, vida = 3;
	bool[] coleccionables = new bool [10];
	float timer, timeraux;
	public int enemigosmatados;
	StreamWriter tiempos;
	StreamReader timepos;


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

		timeractivado = true;
		enemigosmatados = 0;
	

		timer = 0f;
	}

	void Update(){
		/*if (vida <= 0)
			SceneManager.LoadScene ("MenuPrincipal");*/
		if (salud <= 0)
			salud = 3;
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
		
	public void CargaEscena(string escena){
		if (escena == "MenuPrincipal") {
			GuardaTiempos ();
			timer = 0f;
			enemigosmatados = 0;
		}
		SceneManager.LoadScene (escena);
	}

	public bool ActColecc(int i){
		return coleccionables [i];
	}

	public void GuardaTimer () {
		timeraux = timer;
	}

	public void VuelveTimer () {
		timer = timeraux;
	}

	public void GuardaTiempos () {
		GuardaTimer ();
		tiempos = new StreamWriter (Application.dataPath + "/ultimotiempo.txt");
		tiempos.WriteLine (timeraux);
		tiempos.WriteLine (enemigosmatados);
		tiempos.Close ();
	}

	public void LeeStats (out float tiempo, out int enemigos) {
		timepos = new StreamReader (Application.dataPath + "/ultimotiempo.txt");
		tiempo = float.Parse (timepos.ReadLine ());
		enemigos = int.Parse (timepos.ReadLine ());
		timepos.Close ();
	}
}