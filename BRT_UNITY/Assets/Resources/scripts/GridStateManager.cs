using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GridStateManager : MonoBehaviour
{
	int marker = -1;

	public GameObject[] states;
	//array of states
	private GameObject stateHolder;
	// parent
	private GameObject gameObjClone;
	private int stateToDeploy;

	//List<int> MarkerList = new List<int> ();
	//public static int[,] Scanners.currentIds;


	private string[] stateNames = {
		"Error",
		"CurrentStreet",
		"GoldBRT",
		"SilverBRT",
		"GoldBRT & Bike"
	};

	// Use this for initialization
	void Start ()
	{
		stateHolder = new GameObject ("state holder");
		checkMarkerList ();
	}

	void Update() {
		checkMarkerList ();
	}

	private void checkMarkerList ()
	{
		if (Scanners.currentIds.Length == 0) {
			StateMan (0);
		} else if (Scanners.currentIds [0, 0] == 1 && Scanners.currentIds [0, 2] == 1) {
			StateMan (3);
		} else if ((Scanners.currentIds [0, 1] == 4 && Scanners.currentIds [0, 0] == 2) || (Scanners.currentIds [0, 1] == 2 && Scanners.currentIds [0, 0] == 4)) {
			StateMan (4);
		} else {
			StateMan (0);
		}
		Debug.Log ("State change.");	
	}


	private void StateMan (int stateToDeploy)
	{
		foreach (Transform child in stateHolder.transform) { //cleanup of past state gameObj
			GameObject.Destroy (child.gameObject);
		}

		GameObject gameObjClone = (GameObject)Instantiate (states [stateToDeploy], transform.position, transform.rotation);
		gameObjClone.transform.parent = stateHolder.transform;
	}
		
}
