using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webcam : MonoBehaviour
{

	void Awake ()
	{
		
		WebCamTexture webcam = new WebCamTexture (WebCamTexture.devices [0].name); //SET up the cam

		webcam.Play (); // play camera
		Renderer renderer = GetComponent<Renderer> ();
		renderer.material.mainTexture = webcam; //put cam tex onto quad

	}
}
