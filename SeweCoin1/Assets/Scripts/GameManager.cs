using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	bool pause;
	int salud = 3, vida = 3;

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

	}

	void Update(){
		if (Input.GetKeyDown ("p") && pause == false) {
			pause = true;
			Time.timeScale = 0;
		} else if (Input.GetKeyDown ("p") && pause == true) {
			pause = false;
			Time.timeScale = 1;
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
}