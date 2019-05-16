using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSave : MonoBehaviour {

    Animator anim;
    public float speed = 10.0f;
	float movementZ = 0.5f;
	float movementX = 0.5f;
    Rigidbody playerRB;
	float speedModifier;
	public GameObject player; 


    // Use this for initialization
    void Start () {

        playerRB = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
		
	}
 
    //Update is called once per frame
    void Update () {
		//Walk
		speedModifier = 1.0f;
		
        if (Input.GetKeyDown("w")) {
			anim.SetFloat("MoveZ", movementZ);
		}
		if (Input.GetKeyUp("w")) {
			anim.SetFloat("MoveZ", 0.0f);
		}
		if ((Input.GetKeyDown("w")&&Input.GetKey(KeyCode.LeftShift))||(Input.GetKey(KeyCode.LeftShift)&&Input.GetKeyDown("w"))) {
			anim.SetFloat("MoveZ",2*movementZ);
		}
		if (Input.GetKeyUp("w")) {
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
		if (Input.GetKey("w")) 
        {
			anim.SetFloat("MoveZ", movementZ);
            movementZ += 0.03f;
            if (movementZ >= 1) movementZ  = 1;
            player.transform.Translate(Vector3.forward* movementZ * 0.2f);
		}
        else
        {            
             movementZ -= 0.03f;
             if (movementZ <= 0) movementZ = 0;
            anim.SetFloat("MoveZ", movementZ);
            player.transform.Translate(Vector3.forward* movementZ * 0.2f);
        }
		
		if (Input.anyKey)
        {
           if(Input.GetKey(KeyCode.LeftShift)){
            speedModifier = 2.0f;
            }
            if (Input.GetKey("w")) {
                anim.SetFloat("MoveZ", speedModifier * movementZ);
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
			anim.SetFloat("MoveZ", 0.0f);
			anim.SetFloat("MoveX", 0.0f);
		}
		
	}
}