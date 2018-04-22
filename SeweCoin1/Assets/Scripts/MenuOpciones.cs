using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour {

	public AudioMixer audioMixer;

	public void Volumen (float volumen){
		audioMixer.SetFloat ("VolumenPrincipal", volumen);
	}
}
