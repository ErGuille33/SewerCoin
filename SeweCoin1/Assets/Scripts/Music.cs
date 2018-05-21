using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
   
    public AudioClip[] stings;
    public AudioSource stingSource;
    // Use this for initialization
    void Start () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        stingSource.Play();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
