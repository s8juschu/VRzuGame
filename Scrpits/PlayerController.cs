using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typoeof(Animator))]
[RequireComponent(typoeof(Rigidbody))]
[RequireComponent(typoeof(CapsuleCollider))]

public class PlayerController : MonoBehaviour {
	Animator anim;

    bool isWalking = false;


    void Start ()
    {
        anim = GetComponent<Animator>();
    }

	void Update(){
		Turning();
		Walking();
		Move();
	}
	
	void Turning(){
		anim.SezFloat("Turn", Input.GetAxis("Horizontal"));
	}
	
	void Walking(){
		if(Input.GetKeyDown (KeyCode.leftShift)){
			isWalking = !isWalking;
			anim.SetBool ("Walk", isWalking);
		}
	}
	
	void Move(){
		anim.SetFloat("MoveZ", Input.GetAxis("MoveZ"));
		anim.SetFloat("MoveX", Input.GetAxis("MoveX"));

	}
}

