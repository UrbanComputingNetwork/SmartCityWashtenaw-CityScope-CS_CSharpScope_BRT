using UnityEngine;
using System.Collections;

public class cameraGet : MonoBehaviour
{
	
	WebCamTexture webcam = new WebCamTexture ();
	Color[] pixels; 

	IEnumerator Start (){

		while (true) {

		yield return new WaitForSeconds (3);

		Renderer renderer = GetComponent<Renderer> ();
		renderer.material.mainTexture = webcam;

		webcam.Play ();

			Color[] pixels = webcam.GetPixels ();
			for (int i = 0; i < pixels.Length; i++) {
				print (pixels [i]); 

			}
		}
	}
}
