using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehaviour : MonoBehaviour {

	private bool isBeingDragged = false;
	private bool isConnected = false;

	private float distanceToCamera;
    private Connector connectorScript;
    private bool snapped = false;

	private GameObject pointText;
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
            }
			else if(child.name == "PointText")
			{
				pointText = child;
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
			PointAcquired();
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

	private void PointAcquired()
	{
		pointText.SetActive(true);
		StartCoroutine("PointTextAnimation", pointText.GetComponent<Transform>().position + Vector3.up);
		Invoke("DeactivatePointText", 1.5f);
	}

	void DeactivatePointText()
	{
		StopCoroutine("PointTextAnimation");
		pointText.SetActive(false);
	}

	IEnumerator PointTextAnimation (Vector3 target)
	{
		while(Vector3.Distance(pointText.transform.position,target) > 0.05f)
		{
			pointText.transform.position = Vector3.Lerp(pointText.transform.position, target, 2f * Time.deltaTime);
			yield return null;
		}
	}
}
