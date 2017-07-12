using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	public GameObject ToDuplicate;
	public GameObject DuplicateParent;

	private GameObject clonedPin;
	private PinBehaviour pinScript;
	// Use this for initialization
	
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	//	Debug.Log("Update delta time : " + Time.deltaTime);
	}

	void FixedUpdate()
	{
	//	Debug.Log("Fixed Update delta time : " + Time.deltaTime);
	}

	private void OnMouseDown()
	{
		clonedPin = Instantiate(ToDuplicate);
		//clonedPin.transform.position = GameObject.Find("Pins").transform.localPosition;
		pinScript = clonedPin.GetComponent<PinBehaviour>();
		pinScript.IsBeingDragged = true;

		//clonedPin.SetActive(true);
	}

	private void OnMouseUp()
	{
		pinScript.IsBeingDragged = false;
        if (!pinScript.IsConnected)
        {
            Destroy(clonedPin);
        }
	}
}
