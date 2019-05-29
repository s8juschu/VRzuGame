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
        //speedModifier = 0.5f;
        
       	if (Input.anyKey)
        {
            if(Input.GetKey(KeyCode.LeftShift)){
			   speedModifier += 0.05f;
		       while (speedModifier > 2.0f ) speedModifier = 2.0f;  
            }
			if (Input.GetKey("w")) {
				if(!Input.GetKey(KeyCode.LeftShift)){
			    speedModifier = 0.0f;
				}
				anim.SetFloat("MoveZ", speedModifier+movementZ);
				movementZ += 0.05f;
				while (movementZ > 0.5f ) movementZ = 0.5f;
			}
			if (Input.GetKey("s")) {
				anim.SetFloat("MoveZ", movementZ-speedModifier);
				movementZ -= 0.04f;
				while (movementZ < -0.5f ) movementZ = -0.5f;
			}
			if (Input.GetKey("d")) {
				anim.SetFloat("MoveX", movementX);
				movementX += 0.05f;
				while (movementX > 0.5f ) movementX = 0.5f;
			}
			if (Input.GetKey("a")) {
				anim.SetFloat("MoveX", movementX);
				movementX-= 0.04f;
				while (movementX < -0.5f ) movementX= -0.5f;
			}
        }
		else {
			if (movementX > 0.0f)
			{
				Debug.Log("test größer");
			}
			if (movementX < 0.0f)
			{
				Debug.Log("test kleiner");
			}
			anim.SetFloat("MoveZ", 0.0f);
			anim.SetFloat("MoveX", 0.0f);
		}
		
	}
}