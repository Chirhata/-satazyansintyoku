using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveThiefSample : MonoBehaviour {

    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            animator.SetBool("theif_move", true);
        }
    }
}
