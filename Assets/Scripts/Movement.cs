using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Animator anim;
	float movementZ = 0.0f;
	float movementX = 0.0f;
    float speedModifier;
	
	float speedAdjust = 0.05f;



    // Use this for initialization
    void Start () {



        anim = GetComponent<Animator>();
		
	}
 
    //Update is called once per frame
    void Update () {
		//Walk
        //speedModifier = 0.5f;
        
       
            if(Input.GetKey(KeyCode.LeftShift)){
			   speedModifier += 0.05f;
		       if (speedModifier > 2.0f ) speedModifier = 2.0f;  
				this.transform.Translate(Vector3.forward*speedAdjust*speedModifier);
            }
			if (Input.GetKey("w")) {
				if(!Input.GetKey(KeyCode.LeftShift)){
			    speedModifier = 0.0f;
				}
				anim.SetFloat("MoveZ", speedModifier+movementZ);
				movementZ += 0.05f;
				if (movementZ > 0.5f ) movementZ = 0.5f;
				this.transform.Translate(Vector3.forward*speedAdjust);
			}
		else{
				anim.SetFloat("MoveZ", 0);
		}
			if (Input.GetKey("s")) {
				anim.SetFloat("MoveZ", movementZ-speedModifier);
				movementZ -= 0.04f;
				while (movementZ < -0.5f ) movementZ = -0.5f;
					this.transform.Translate(Vector3.forward*speedAdjust*-0.5f);
			}else{
				if(!Input.GetKey("w")){
					anim.SetFloat("MoveZ", 0f);
				}
			}
			if (Input.GetKey("d")) {
				anim.SetFloat("MoveX", movementX);
				movementX += 0.05f;
				if (movementX > 0.5f ) movementX = 0.5f;
				this.transform.Rotate(0,1f,0);
			}else{
				if(!Input.GetKey("a")){
					anim.SetFloat("MoveX", 0f);
				}
			}
			if (Input.GetKey("a")) {
				anim.SetFloat("MoveX", movementX);
				movementX-= 0.04f;
				if (movementX < -0.5f ) movementX= -0.5f;
				this.transform.Rotate(0,-1f,0);
			}else{
				if(!Input.GetKey("d")){
				anim.SetFloat("MoveX", 0f);
				}
			}
        }
		
		
	
}