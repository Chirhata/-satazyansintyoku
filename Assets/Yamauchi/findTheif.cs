using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class findTheif : MonoBehaviour {
    public Material[] texutureMark = new Material[2];
    GameObject excrumationMark;
	// Use this for initialization
	void Start () {
        excrumationMark = GameObject.Find("excrumationMark");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
        //Destroy(this);
        Debug.Log("in a time");
        excrumationMark.GetComponent<Renderer>().material = texutureMark[0];

    }
    private void OnTriggerExit(Collider other)
    {
        excrumationMark.GetComponent<Renderer>().material = texutureMark[1];
    }
}
