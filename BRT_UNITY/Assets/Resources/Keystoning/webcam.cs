using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webcam : MonoBehaviour
{
  	public static WebCamTexture webcamera;
    public static bool isPlaying = false;

    void OnEnable()
    {
		string webcamName = WebCamTexture.devices [0].name;
		webcamera = new WebCamTexture (webcamName); //SET up the cam
		Debug.Log("Webcam texture set from " + webcamName);

        Setup();
    }
    
    void Setup()
    {
        webcamera.Play(); // play camera
        isPlaying = true;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamera; //put cam tex onto quad
        Debug.Log("Webcam assigned");
    }

    public static void Pause()
    {
        webcamera.Pause();
        isPlaying = false;
    }

    public static void Play()
    {
        webcamera.Play();
        isPlaying = true;
	}
    
}
