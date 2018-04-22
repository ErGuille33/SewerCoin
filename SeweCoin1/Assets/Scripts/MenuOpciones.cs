using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour {

	public AudioMixer audioMixer;
	public Dropdown ListaResoluciones;

	Resolution[] resoluciones;

	void Start(){
		resoluciones = Screen.resolutions;

		ListaResoluciones.ClearOptions ();

		List<string> options = new List<string> ();

		int currentResolutionIndex = 0;
		for (int i = 0;	i < resoluciones.Length; i++) {

			string option = resoluciones[i].width + "x" + resoluciones[i].height;
			options.Add (option);

			if (resoluciones [i].width == Screen.currentResolution.width && resoluciones [i].height == Screen.currentResolution.height)
				currentResolutionIndex = i;
		}

		ListaResoluciones.AddOptions (options);
		ListaResoluciones.value = currentResolutionIndex;
		ListaResoluciones.RefreshShownValue ();

	}

	public void Resolucion(int resolutionIndex){

		Resolution resolucion = resoluciones [resolutionIndex];
		Screen.SetResolution (resolucion.width, resolucion.height, Screen.fullScreen);
	}

	public void Volumen (float volumen){
		
		audioMixer.SetFloat ("VolumenPrincipal", volumen);
	}

	public void Graficos(int qualityIndex){
		
		QualitySettings.SetQualityLevel (qualityIndex);
	}

	public void PantallaCompleta (bool esCompleta){
		
		Screen.fullScreen = esCompleta;
	}
}
