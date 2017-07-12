using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameManager : Singleton<SGameManager> {

    public GameObject[] buttons;

    protected override void Init(){}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] pins = GameObject.FindGameObjectsWithTag("Pins");
        Debug.Log("pinsLength = " + pins.Length);
        if(pins.Length > 3)
        {
            foreach (GameObject button in buttons)
            {
                button.GetComponent<Button>().BlockSummon = true;
            }
        }
        else
        {
            foreach (GameObject button in buttons)
            {
                button.GetComponent<Button>().BlockSummon = false;
            }
        }
	}
}
