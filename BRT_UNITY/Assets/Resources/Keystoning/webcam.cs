﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webcam : MonoBehaviour
{
  	public static WebCamTexture webcamera;

    void OnEnable()
    {
		string webcamName = WebCamTexture.devices [0].name;
		webcamera = new WebCamTexture (webcamName); //SET up the cam
		Debug.Log("Webcam texture set from " + webcamName);

        Setup();
    }
    
    void Setup()
    {
        Play(); // play camera
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamera; //put cam tex onto quad
        Debug.Log("Webcam assigned and playing: " + webcamera.isPlaying);
    }

    public static bool isPlaying()
    {
        return webcamera.isPlaying;
    }

    public static void Pause()
    {
        webcamera.Pause();
    }

    public static void Play()
    {
        int counter = 0;
        while (!isPlaying() && counter < 50)
        {
            webcamera.Play();
            counter++;
        }
    }

    public static void Stop()
    {
        webcamera.Stop();
    }
}
