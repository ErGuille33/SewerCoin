using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Vector2 velocity;

	public float alturaCamara;
	float posX,posY;
	public float smoothTimeY;
	public float smoothTimeX;
	private float upBorder, downBorder;
	public GameObject player;
	Camera cam;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		cam = GetComponent<Camera> ();
		posY = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		 posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		 transform.position = new Vector3 (posX, posY, transform.position.z);
		posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
		transform.position = new Vector3 (posX, posY, transform.position.z);

	}


	/*void Update(){
		Vector3 viewPosition = cam.WorldToViewportPoint(player.transform.position);
		if (viewPosition.y > 1f) {
			posY = posY + alturaCamara;
			transform.position = new Vector3 (transform.position.x, posY, transform.position.z);
		} // move rup
		else if( viewPosition.y < 0f ) {
			posY = posY - alturaCamara;
			transform.position = new Vector3 (transform.position.x, posY, transform.position.z);
		}// move down
	}*/
	}

