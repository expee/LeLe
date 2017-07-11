using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour {

	private bool isConnected = false;
	private PinBehaviour parentPinScript;
	// Use this for initialization
	void Start () {
		parentPinScript = gameObject.transform.parent.GetComponent<PinBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
			}
		}
	}
}
