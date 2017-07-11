using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehaviour : MonoBehaviour {

	private bool isBeingDragged = false;
	private bool isConnected = false;

	private float distanceToCamera;
    private Connector connectorScript;
    private bool snapped = false;
	// Use this for initialization
	void Start ()
	{
        for(int i = 0; i < gameObject.GetComponent<Transform>().childCount; i++)
        {
            GameObject child = gameObject.GetComponent<Transform>().GetChild(i).gameObject;
            if(child.name == "LeftConnector")
            {
                Debug.Log("Child Name is = " + child.name);
                connectorScript = child.GetComponent<Connector>();
                break;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isBeingDragged)
		{
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector2 rayHit = mouseRay.GetPoint(distanceToCamera);
			gameObject.transform.position = rayHit;
		}
        else if(!IsBeingDragged && !snapped && isConnected)
        {
            gameObject.GetComponent<Transform>().position = connectorScript.SnappingPoint;
            snapped = true;
        }
	}

	public bool IsConnected
	{
		get
		{
			return isConnected;
		}

		set
		{
			isConnected = value;
		}
	}

	public bool IsBeingDragged
	{
		get
		{
			return isBeingDragged;
		}

		set
		{
			isBeingDragged = value;
			if (isBeingDragged == true)
			{
				distanceToCamera = Vector3.Distance(transform.position, GameObject.Find("Main Camera").transform.position);
				Debug.Log("isBeingDragged-nya " + gameObject.name + " Jadi true Pak!!");
			}
			else
			{
				Debug.Log("isBeingDragged-nya " + gameObject.name + " Jadi false Pak!!");
			}
		}
	}
}
