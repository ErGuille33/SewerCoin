using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectables : MonoBehaviour {

	public int awardnumber;
    void Update()
    {
        if(gameObject.tag == "award")
        iTween.MoveAdd(gameObject, iTween.Hash("y", 0.3f, "easeType", "easeinOutSine", "loopType", "pingPong"));
    }
    void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			if (this.gameObject.tag == "award") {
				GameManager.instance.ActivaAward (awardnumber);
			}
			Destroy (gameObject);
		}

	}
}
