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
    private bool blockSummon = false;


    public bool BlockSummon
    {
        get
        {
            return blockSummon;
        }
        set
        {
            blockSummon = value;
        }
    }
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
        if(!blockSummon)
        {
            clonedPin = Instantiate(ToDuplicate);
            pinScript = clonedPin.GetComponent<PinBehaviour>();
            pinScript.IsBeingDragged = true;
        }
	}

	private void OnMouseUp()
	{
        if(pinScript != null)
        {
            pinScript.IsBeingDragged = false;
            if (!pinScript.IsConnected)
            {
                Destroy(clonedPin);
            }
        }
	}
}
