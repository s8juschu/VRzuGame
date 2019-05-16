using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Animator anim;
	float movementZ = 0.0f;
	float movementX = 0.0f;
    float speedModifier;
    Rigidbody playerRB;


    // Use this for initialization
    void Start () {

        playerRB = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
		
	}
 
    //Update is called once per frame
    void Update () {
		//Walk
        speedModifier = 1.0f;
        
       	if (Input.anyKey)
        {
           if(Input.GetKey(KeyCode.LeftShift)){
            speedModifier = 2.0f;
            }
            if (Input.GetKey("w")) {
				if (movementZ < 0.5f ){
					movementZ += 0.05f;
               		anim.SetFloat("MoveZ", movementZ);
				}
				if (movementZ >= 0.5f ){
					movementZ = 0.5f;
					anim.SetFloat("MoveZ", movementZ);
				}
            }
			if (Input.GetKey("s")) {
				anim.SetFloat("MoveZ", -movementZ);
			}
			if (Input.GetKey("d")) {
				anim.SetFloat("MoveX", movementX);
			}
			if (Input.GetKey("a")) {
				anim.SetFloat("MoveX", -movementX);
			}
        }
		else {
			if (movementZ > 0.0f ){
					movementZ -= 0.05f;
               		anim.SetFloat("MoveZ", movementZ);
				}
			anim.SetFloat("MoveZ", 0.0f);
			anim.SetFloat("MoveX", 0.0f);
		}
		
	}
}