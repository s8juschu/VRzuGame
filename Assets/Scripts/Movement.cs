using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    Animator anim;
	float movementZ = 0.0f;
	float movementX = 0.0f;
    float speedModifier;
	float speedAdjust = 0.05f;
	
	[SerializeField] private Text countText;
	[SerializeField] private Text winText;
    static public int count;
	
	public int numPotions;
	
	private AudioSource[] sounds;
    private AudioSource collectAudio;
    private AudioSource specialAudio;
	
	private GameObject kessel;
	private GameObject kesselFeuer;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();		
		sounds = GetComponents<AudioSource>();
        collectAudio = sounds[0];
        specialAudio = sounds[1];
		
		kessel = GameObject.Find ("Kessel");
		kesselFeuer = GameObject.Find ("KesselFeuer");
		kesselFeuer.SetActive(false); 
		
		count = 0;
        SetCountText ();
	}
 
    //Update is called once per frame
    void Update () {
       
		if (Input.GetKey("w")) {
			speedModifier += 0.05f; 
		    if (speedModifier > 2.0f ) speedModifier = 2.0f;  
			anim.SetFloat("MoveZ", speedModifier+movementZ);
			movementZ += 0.04f;
			if (movementZ > 0.6f ) speedAdjust = 0.15f;
			if (movementZ > 1.0f ) movementZ = 1.0f;
			this.transform.Translate(Vector3.forward*speedAdjust);
		}else{
				speedModifier = 0.0f;
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
			this.transform.Rotate(0,2.0f,0);
		}else{
			if(!Input.GetKey("a")){
				anim.SetFloat("MoveX", 0f);
			}
		}
		if (Input.GetKey("a")) {
			anim.SetFloat("MoveX", movementX);
			movementX-= 0.04f;
			if (movementX < -0.5f ) movementX= -0.5f;
			this.transform.Rotate(0,-2.0f,0);
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
		
		if (other.gameObject.CompareTag ("RundPotion"))
        {
            other.gameObject.SetActive (false);
			count = count + 15;
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
				
		if	(other.gameObject.CompareTag ("KesselFeuer")){
			winText.text = "You won!";
		}
				
    }
	
		
	 void OnCollisionEnter(Collision other)
    {
        if	(other.gameObject.CompareTag ("KesselFeuer")){
			winText.text = "You won!";
			SceneManager.LoadScene("WinScene");
		}
    }
	
	void SetCountText ()
    {
        countText.text = "Points: " + count.ToString ();
        if (numPotions<= 0)
        {
            winText.text = "All potions found! Bring them to the cauldron.";
			kesselFeuer.SetActive(true); 
			kessel.SetActive(false); 
        }
    }
}