using UnityEngine;
using System.Collections;

public class stateLoaderKeyboard : MonoBehaviour {

    public GameObject state1;
    public GameObject state2;
    public GameObject state3;
    public GameObject state4;
    public GameObject state5;

    public GameObject newParent;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

                if (Input.GetKeyDown(KeyCode.Q))
                {
            clearParent();
                GameObject thisState = Instantiate(state1);
                    thisState.transform.parent = newParent.transform;

                }

                else if (Input.GetKeyDown(KeyCode.W))
                {
            clearParent();

            GameObject thisState = Instantiate(state2);
                    thisState.transform.parent = newParent.transform;
                }

                else if (Input.GetKeyDown(KeyCode.E))
                {
            clearParent();

            GameObject thisState = Instantiate(state3);
                    thisState.transform.parent = newParent.transform;
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
            clearParent();

            GameObject thisState = Instantiate(state4);
                    thisState.transform.parent = newParent.transform;
                }
                else if (Input.GetKeyDown(KeyCode.T))
                {
            clearParent();

            GameObject thisState = Instantiate(state5);
                    thisState.transform.parent = newParent.transform;
                }

            }

    void clearParent()
    {
        foreach (Transform child in newParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
        }
  