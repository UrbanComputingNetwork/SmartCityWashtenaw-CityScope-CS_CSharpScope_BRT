/* using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Utility;

public class VehicleSpawner : MonoBehaviour
{

	public float delaySecondsPedestians = 0.1f;
	public int randomFactor = 3;
	public GameObject agentPrefab;
	public List<WaypointCircuit> routes;

	IEnumerator Start ()
	{
		while (true) {

			if (Random.Range (1, randomFactor) == 1) {
				var checkResult = Physics.OverlapSphere (transform.position, 5); //make sure spawner is clear 
				if (checkResult.Length == 0) {
					var agent = Instantiate (agentPrefab, transform.position, transform.rotation, transform) as GameObject;
					var rand = new System.Random ();
					var idx = rand.Next (routes.Count);
					var route = routes [idx];

					agent.GetComponent<WaypointProgressTracker> ().circuit = route;
				} else {
					Debug.Log ("can't spawn due to collision");
				}
			}
			yield return new WaitForSeconds (delaySecondsPedestians);
		}
	}
} */