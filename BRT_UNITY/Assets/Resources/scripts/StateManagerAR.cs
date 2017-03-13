using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class StateManagerAR : MonoBehaviour
{
	AROrigin arOrigin;
	ARMarker marker = null;

	public GameObject[] states;
	//array of states
	private GameObject stateHolder;
	// parent
	private GameObject gameObjClone;
	private int stateToDeploy;

	List<ARMarker> MarkerList = new List<ARMarker> ();

	// Use this for initialization
	void Start ()
	{
		arOrigin = this.gameObject.GetComponentInParent<AROrigin> (); // Unity v4.5 and later.
		stateHolder = new GameObject ("state holder");
		checkMarkerList ();
	}

	void OnMarkerFound (ARMarker marker)
	{

		MarkerList.Add (marker); //add found markers to list

		Debug.Log ("FOUND >> " + marker.Tag + " |  The list has " + MarkerList.Count + " markers now.");
		for (int i = 0; i < MarkerList.Count; i++) {
			Debug.Log ("Item: " + i + " in list tag is: " + MarkerList [i].Tag);

		}

		checkMarkerList ();

	}


	void OnMarkerLost (ARMarker marker)
	{
		MarkerList.Remove (marker);

		Debug.Log ("LOST << " + marker.Tag + " |  The list has " + MarkerList.Count + " markers now.");
		for (int i = 0; i < MarkerList.Count; i++) {
			Debug.Log ("Item: " + i + " in list tag is: " + MarkerList [i].Tag);

		}

		checkMarkerList ();

	}

	private void checkMarkerList ()
	{
		
		if (MarkerList.Count == 0) {
			StateMan (0);
		} else if (MarkerList.Count == 1) {
			if (MarkerList [0].Tag.Equals ("GoldBRT")) {
				StateMan (3);

			} else if (MarkerList [0].Tag.Equals ("BikeLane")) {
				StateMan (0);
			} 
		} else if (MarkerList.Count == 2) {
			if (MarkerList [0].Tag.Equals ("GoldBRT") && MarkerList [1].Tag.Equals ("BikeLane") || MarkerList [1].Tag.Equals ("GoldBRT") && MarkerList [0].Tag.Equals ("BikeLane")) {
				StateMan (4);
			} else {
				StateMan (0);
			}

			MarkerList.Clear ();
			Debug.Log ("cleared list!");	
		}
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
