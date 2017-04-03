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

	List<int> MarkerList = new List<int> ();

	// Use this for initialization
	void Start ()
	{
		stateHolder = new GameObject ("state holder");
		checkMarkerList ();
	}

	void OnMarkerFound (int marker)
	{

		MarkerList.Add (marker); //add found markers to list

		Debug.Log ("FOUND >> " + marker + " |  The list has " + MarkerList.Count + " markers now.");
		for (int i = 0; i < MarkerList.Count; i++) {
			Debug.Log ("Item: " + i + " in list tag is: " + MarkerList [i]);

		}

		checkMarkerList ();

	}


	void OnMarkerLost (int marker)
	{
		MarkerList.Remove (marker);

		Debug.Log ("LOST << " + marker + " |  The list has " + MarkerList.Count + " markers now.");
		for (int i = 0; i < MarkerList.Count; i++) {
			Debug.Log ("Item: " + i + " in list tag is: " + MarkerList [i]);

		}
		checkMarkerList ();
	}

	private void checkMarkerList ()
	{
		
		if (MarkerList.Count == 0) {
			StateMan (0);
		} 
//		else if (MarkerList.Count == 1) {
//			if (MarkerList [0].Tag.Equals ("GoldBRT")) {
//				StateMan (3);
//
//			} else if (MarkerList [0].Tag.Equals ("BikeLane")) {
//				StateMan (0);
//			} 
//		} else if (MarkerList.Count == 2) {
//			if (MarkerList [0].Tag.Equals ("GoldBRT") && MarkerList [1].Tag.Equals ("BikeLane") || MarkerList [1].Tag.Equals ("GoldBRT") && MarkerList [0].Tag.Equals ("BikeLane")) {
//				StateMan (4);
//			} else {
//				StateMan (0);
//			}
//
//			MarkerList.Clear ();
//			Debug.Log ("cleared list!");	
//		}
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
