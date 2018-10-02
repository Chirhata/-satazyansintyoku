using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thief_move : MonoBehaviour {
    public Material[] thiefTexture = new Material[2];
    GameObject theif;
	// Use this for initialization
	void Start () {
        theif = GameObject.Find("theif");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
