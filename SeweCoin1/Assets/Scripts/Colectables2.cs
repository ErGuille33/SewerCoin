using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Colectables2 : MonoBehaviour {

	public int awardnumber;
	public GameObject imagen;
	public Text textos;

	static int contador = 0;

	void Start()
	{
		contador = 0;
		if (GameManager.instance.ActColecc (awardnumber))
			Destroy (gameObject);

        if (SceneManager.GetActiveScene().name == "Escena1")
        for (int i = 0; i < 5; i++) {
            if (GameManager.instance.ActColecc(i))
                contador++;
                    }
        else if (SceneManager.GetActiveScene().name == "Escena2")
            for (int i = 5; i < 10; i++) {
                if (GameManager.instance.ActColecc(i))
                    contador++;
            }

    }

	void Update()
	{
		if(gameObject.tag == "award")
			iTween.MoveAdd(gameObject, iTween.Hash("y", 0.3f, "easeType", "easeinOutSine", "loopType", "pingPong"));
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			if (this.gameObject.tag == "award") {
				GameManager.instance.ActivaAward (awardnumber);
				contador++;
				imagen.SetActive (true);
				textos.text = " Colecc: " + contador + "/5";
			}
			Destroy (gameObject);
		}
	}
}
