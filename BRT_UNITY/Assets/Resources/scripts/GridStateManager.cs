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
    private int currState = 0;
    private int counter = 0;

	//public static int[,] Scanners.currentIds;
    // red 0  white 1  black 2 

	enum StreetState { 
		ERROR, 
		CURRENT_STREET,
		GOLD_BRT,
		SILVER_BRT,
		GOLD_BRT_BIKE
	}

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
        if (Scanners.currentIds == null)
        {
            Debug.Log("No IDs");
            return;
        }

        if (Scanners.currentIds.Length == 0) {
			StateMan (StreetState.ERROR);
		} 
		else if (Scanners.currentIds[0, 0] == 0 && Scanners.currentIds[0, 2] == 0 && Scanners.currentIds [0, 1] == -1)
		{
			StateMan (StreetState.CURRENT_STREET);
		}
		else if (Scanners.currentIds [0, 0] == 1 && Scanners.currentIds [0, 2] == 1 && Scanners.currentIds [0, 1] == -1)
        {
			StateMan (StreetState.GOLD_BRT);
		}
		else if (Scanners.currentIds[0, 1] == 2 && Scanners.currentIds[0, 0] == 0 && Scanners.currentIds [0, 2] == -1)
        {
			StateMan(StreetState.GOLD_BRT_BIKE);
        }
		else if (Scanners.currentIds[0, 1] == 2 && Scanners.currentIds[0, 0] == -1 && Scanners.currentIds [0, 2] == -1)
        {
			StateMan(StreetState.SILVER_BRT);
        }
        
        else {
			StateMan (StreetState.ERROR);
		}
			
	}


	private void StateMan (StreetState stateToDeploy)
	{
        if (currState == stateToDeploy) return;

        if (counter < 20)
        {
            counter++;
            return;
        }

        currState = stateToDeploy;
        counter = 0;

		foreach (Transform child in stateHolder.transform) { //cleanup of past state gameObj
			GameObject.Destroy (child.gameObject);
		}

		GameObject gameObjClone = (GameObject)Instantiate (states [stateToDeploy], transform.position, transform.rotation);
		gameObjClone.transform.parent = stateHolder.transform;
	}
		
}
