using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour {

	private bool isConnected = false;
	private PinBehaviour parentPinScript;
    private GameObject parentPin;

    private Vector3 snappingPoint;
	// Use this for initialization
	void Start () {
		parentPinScript = gameObject.GetComponent<Transform>().parent.GetComponent<PinBehaviour>();
        parentPin= gameObject.GetComponent<Transform>().parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 SnappingPoint
    {
        get
        {
            return snappingPoint;
        }
        set
        {
            snappingPoint = value;
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

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name + " dan " + name + " Tubrukan");
		if (other.name != name & name == "LeftConnector" && other.name == "RightConnector")
		{
			Connector RCon = other.GetComponent<Connector>();
			if(RCon.IsConnected == false)
			{
				IsConnected = true;
				RCon.IsConnected = true;
				parentPinScript.IsConnected = true;
				Debug.Log("Konek!!");
                GameObject othersParent = other.transform.parent.gameObject;
                Debug.Log("Collider size = " + othersParent.GetComponent<Collider>().bounds.size);
                snappingPoint = SetParentPosition(othersParent);
            }
		}
	}

    private Vector3 SetParentPosition (GameObject otherObject)
    {
        Vector3 othersSize = otherObject.GetComponent<Collider>().bounds.size;
        Vector3 othersPos = otherObject.GetComponent<Transform>().position;
        Vector3 parentPos = parentPin.GetComponent<Transform>().position;
        Vector3 parentSize = parentPin.GetComponent<Collider>().bounds.size;

        Vector3 snappingPos = new Vector3(
            othersPos.x + (othersSize.x / 2) + parentSize.x / 2,
            othersPos.y + (othersSize.y / 2) - parentSize.y / 2,
            othersPos.z
            );
        return snappingPos;
    }
}
