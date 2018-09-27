using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class findTheif : MonoBehaviour {
    public Material[] texutureMark = new Material[2];
    GameObject excrumationMark;
    public Material[] theifTexture = new Material[8];
    GameObject theif;
    public AudioClip[] music = new AudioClip[5]; 
    private AudioSource audioSource;
    int i = 0;
	// Use this for initialization
	void Start () {
        excrumationMark = GameObject.Find("excrumationMark");
        theif = GameObject.Find("theif");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
        //Destroy(this);
        Debug.Log("in a time");
        excrumationMark.GetComponent<Renderer>().material = texutureMark[0];
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = music[3];
        audioSource.Play ();
        MoveRightTheif();

    }
    private void OnTriggerExit(Collider other)
    {
        excrumationMark.GetComponent<Renderer>().material = texutureMark[1];
    }
    private void MoveRightTheif(){
        i++;
        theif.GetComponent<Renderer>().material = theifTexture[i];
        Invoke("MoveTheif", 0.1f);
        if (i > 6) i = 0;
    }
}
