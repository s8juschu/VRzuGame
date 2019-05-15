using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Animator anim;
    public float speed = 10.0f;
	float movementZ = 0.5f;
	float movementX = 0.5f;
    Rigidbody playerRB;


    // Use this for initialization
    void Start () {

        playerRB = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
		
	}
 
    //Update is called once per frame
    void Update () {
		//Walk
		
        if (Input.GetKeyDown("w")) {
			anim.SetFloat("MoveZ", movementZ);
		}
		if (Input.GetKeyUp("w")) {
			anim.SetFloat("MoveZ", 0.0f);
		}
		if (Input.GetKeyDown("w")&&Input.GetKey(KeyCode.LeftShift)) {
			anim.SetFloat("MoveZ",2*movementZ);
		}
		if (Input.GetKeyUp("w")&&Input.GetKey(KeyCode.LeftShift)) {
			anim.SetFloat("MoveZ", 0.0f);
		}
		if (Input.GetKeyDown("s")) {
			anim.SetFloat("MoveZ", -movementZ);
		}
		if (Input.GetKeyUp("s")) {
			anim.SetFloat("MoveZ", 0.0f);
		}
		if (Input.GetKeyDown("d")) {
			anim.SetFloat("MoveX", movementX);
		}
		if (Input.GetKeyUp("d")) {
			anim.SetFloat("MoveX", 0.0f);
		}
	    if (Input.GetKeyDown("a")) {
			anim.SetFloat("MoveX", -movementX);
		}
		if (Input.GetKeyUp("a")) {
			anim.SetFloat("MoveX", 0.0f);
		}
		
	}
}