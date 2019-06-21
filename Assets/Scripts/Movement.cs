using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    Animator anim;
	float movementZ = 0.0f;
	float movementX = 0.0f;
    float speedModifier;
	float speedAdjust = 0.05f;
	
	[SerializeField] private Text countText;
	[SerializeField] private Text winText;
    private int count;
	
	public int numPotions;
	
	public AudioSource[] sounds;
    public AudioSource collectAudio;
    public AudioSource specialAudio;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();	
		sounds = GetComponents<AudioSource>();
        collectAudio = sounds[0];
        specialAudio = sounds[1];
		
		count = 0;
        SetCountText ();
	}
 
    //Update is called once per frame
    void Update () {
        //speedModifier = 0.5f;        
       
		if(Input.GetKey(KeyCode.LeftShift)){
           speedAdjust = 0.15f;
		   speedModifier += 0.05f;
		   if (speedModifier > 2.0f ) speedModifier = 2.0f;  
			//this.transform.Translate(Vector3.forward*speedAdjust*speedModifier);
		}else{
				speedAdjust = 0.05f;
		}
		if (Input.GetKey("w")) {
			if(!Input.GetKey(KeyCode.LeftShift)){
			speedModifier = 0.0f;
			}
			anim.SetFloat("MoveZ", speedModifier+movementZ);
			movementZ += 0.05f;
			if (movementZ > 0.5f ) movementZ = 0.5f;
			this.transform.Translate(Vector3.forward*speedAdjust);
		}else{
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
			this.transform.Rotate(0,1.5f,0);
		}else{
			if(!Input.GetKey("a")){
				anim.SetFloat("MoveX", 0f);
			}
		}
		if (Input.GetKey("a")) {
			anim.SetFloat("MoveX", movementX);
			movementX-= 0.04f;
			if (movementX < -0.5f ) movementX= -0.5f;
			this.transform.Rotate(0,-1.5f,0);
		}else{
			if(!Input.GetKey("d")){
			anim.SetFloat("MoveX", 0f);
			}
		}
	}
		
	   void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Potion"))
        {
            other.gameObject.SetActive (false);
			count = count + 10;
			numPotions --;
            SetCountText ();
			collectAudio.Play();
        }
		   
		if (other.gameObject.CompareTag ("Blume"))
        {
            other.gameObject.SetActive (false);
			count = count + 20;
            SetCountText ();
			specialAudio.Play();
        }
		   
		if (other.gameObject.CompareTag ("Stab"))
        {
            other.gameObject.SetActive (false);
			count = count + 30;
            SetCountText ();
			specialAudio.Play();
        }   
    }
	
	void SetCountText ()
    {
        countText.text = "Points: " + count.ToString ();
        if (numPotions<= 0)
        {
            winText.text = "All potions found! Bring them to the cauldron.";
        }
    }
}