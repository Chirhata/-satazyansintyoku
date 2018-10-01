using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class findTheif : MonoBehaviour {
    public Material[] texutureMark = new Material[2];
    GameObject excrumationMark;
    public Material[] theifTexture = new Material[16];
    GameObject theif;
    public AudioClip[] music = new AudioClip[5]; 
    private AudioSource audioSource;
    private int state = 1;
    private float timeleft;
    int i = 0;
    int j = 0;
	// Use this for initialization
	void Start () {
        excrumationMark = GameObject.Find("excrumationMark");
        theif = GameObject.Find("theif");
    }
	
	// Update is called once per frame
	void Update () {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 0.1f;
            theif.GetComponent<Renderer>().material = theifTexture[i];
            i++;
        }
        if (i > 15) i = 0;
	}

    private void OnTriggerEnter(Collider other)
    {
        

        //Debug.Log("hit object!");
        excrumationMark.GetComponent<Renderer>().material = texutureMark[0];  //ビックリマークのテクスチャ変更
        audioSource = this.GetComponent<AudioSource>(); 
        audioSource.clip = music[3];
        audioSource.Play ();
        Invoke("StateCheck", 1.0f);
        Invoke("TurnOffTrigger", 1.1f);

    }

    //ライトが対象から外れた時の動作
    private void OnTriggerExit(Collider other)
    {
        excrumationMark.GetComponent<Renderer>().material = texutureMark[1];  //ビックリマークのテクスチャ変更
        CancelInvoke();
    }


        // 泥棒が右に動く動作
    private void MoveRightTheif()
    {
        theif.GetComponent<Animator>().SetBool("RightTrigger", true);

    }

        //泥棒が左に動く動作
    private void MoveLeftTheif()
    {
        theif.GetComponent<Animator>().SetBool("LeftTrigger", true);

    }

    public void StateCheck(){

        switch (state)
        {
            //一番左にいる時
            case 1:

                MoveRightTheif();
                state = 3;
                Debug.Log("in Center");
                break;

            //一番右にいる時
            case 2:

                MoveLeftTheif();
                state = 3;
                Debug.Log("in Center");
                break;
            //どちらも行ける時
            case 3:
                int temp;
                temp = Random.Range(0, 2);


                if (temp == 1)
                {
                    state = 2;
                    MoveRightTheif();
                    Debug.Log("in Right");
                    break;
                }

                else
                {
                    state = 1;
                    MoveLeftTheif();
                    Debug.Log("in Left");
                    break;
                }
                break;
        }
    }

    private void TurnOffTrigger(){
        theif.GetComponent<Animator>().SetBool("RightTrigger", false);
        theif.GetComponent<Animator>().SetBool("LeftTrigger", false);
    }

    //毎フレーム泥棒のテクスチャを変更する
    private void ChangeMaterial(int i)
    {
        theif.GetComponent<Renderer>().material = theifTexture[j];
        j++;
        if (j > i+8) j = 0;
    }

}
