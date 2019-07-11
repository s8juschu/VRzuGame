using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovementPlayer2 : MonoBehaviour {

    Animator anim;
	float movementZ = 0.0f;
	float movementX = 0.0f;
    float speedModifier;
	float speedAdjust = 0.05f;
	
	[SerializeField] private Text countText;
	[SerializeField] private Text winText;
    static public int count;
	
	public int numPotions;
	static public int numPotionsPublic = 7;
	
	private AudioSource[] sounds;
    private AudioSource collectAudio;
    private AudioSource specialAudio;
	
	private GameObject kessel;
	private GameObject kesselFeuer;


    // Use this for initialization
    void Start () {
		numPotionsPublic = numPotions;
        anim = GetComponent<Animator>();		
		sounds = GetComponents<AudioSource>();
        collectAudio = sounds[0];
        specialAudio = sounds[1];
		
		kessel = GameObject.Find ("Kessel");
		kesselFeuer = GameObject.Find ("KesselFeuer");
		//kesselFeuer.SetActive(false); 
		
		count = 0;
        SetCountText ();
	}
 
    //Update is called once per frame
    void Update () {
       
		if (Input.GetKey("i")) {
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
		if (Input.GetKey("k")) {
			anim.SetFloat("MoveZ", movementZ-speedModifier);
			movementZ -= 0.04f;
			while (movementZ < -0.5f ) movementZ = -0.5f;
				this.transform.Translate(Vector3.forward*speedAdjust*-0.5f);
		}else{
			if(!Input.GetKey("i")){
				anim.SetFloat("MoveZ", 0f);
			}
		}
		if (Input.GetKey("l")) {
			anim.SetFloat("MoveX", movementX);
			movementX += 0.05f;
			if (movementX > 0.5f ) movementX = 0.5f;
			this.transform.Rotate(0,2.0f,0);
		}else{
			if(!Input.GetKey("j")){
				anim.SetFloat("MoveX", 0f);
			}
		}
		if (Input.GetKey("j")) {
			anim.SetFloat("MoveX", movementX);
			movementX-= 0.04f;
			if (movementX < -0.5f ) movementX= -0.5f;
			this.transform.Rotate(0,-2.0f,0);
		}else{
			if(!Input.GetKey("l")){
			anim.SetFloat("MoveX", 0f);
			}
		}
		
		if (Movement.numPotionsPublic <= 0)
        {
            winText.text = "All herbs found! Bring them to the cauldron.";
			kesselFeuer.SetActive(true); 
			kessel.SetActive(false); 
        }
	}
		
	  	   void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Potion"))
        {
            other.gameObject.SetActive (false);
			count = count + 10;
            SetCountText ();
			collectAudio.Play();
        }
		if (other.gameObject.CompareTag ("klein"))
        {
            other.gameObject.SetActive (false);
			count = count + 10;
            SetCountText ();
			this.transform.localScale = new Vector3(4,4,4);
			collectAudio.Play();
        }
		
		if (other.gameObject.CompareTag ("groß"))
        {
            other.gameObject.SetActive (false);
			count = count + 10;
            SetCountText ();
			this.transform.localScale = new Vector3(30,30,30);
			collectAudio.Play();
        }
				
		if (other.gameObject.CompareTag ("Specialherb"))
        {
            other.gameObject.SetActive (false);
			count = count + 15;
			numPotionsPublic --;
			 Movement.numPotionsPublic --;
            SetCountText ();
			collectAudio.Play();
        }
		
		if (other.gameObject.CompareTag ("Herb"))
        {
            other.gameObject.SetActive (false);
			count = count + 10;
			numPotionsPublic --;
			 Movement.numPotionsPublic --;
            SetCountText ();
			collectAudio.Play();
        }
		
		if (other.gameObject.CompareTag ("NormalPotion"))
        {
			this.transform.localScale = new Vector3(10,10,10);
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
			count = count + 20;
            SetCountText ();
			specialAudio.Play();
        }  
				
		if	(other.gameObject.CompareTag ("Fliegenpilz")){
			other.gameObject.SetActive (false);
			count = count - 40;
            SetCountText ();
			specialAudio.Play();
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
        if (numPotionsPublic<= 0 ||  Movement.numPotionsPublic <= 0)
        {
            winText.text = "All herbs found! Bring them to the cauldron.";
			kesselFeuer.SetActive(true); 
			kessel.SetActive(false); 
        }
    }
}