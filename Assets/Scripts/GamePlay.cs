using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlay : MonoBehaviour
{
	 [SerializeField] private Text timeText;
     [SerializeField] private float mainTimer;
	 
	 private float timer;
	 private bool canCount = true;
	 private bool doOnce = false;
     
     // Use this for initialization
     void Start () {
     	timer = mainTimer;     
     }
     
     // Update is called once per frame
     void Update () {

	   if ( timer >= 0.0f && canCount){
	  	 timer -= Time.deltaTime;
		 timeText.text =  "Time left: " + timer.ToString("F") + " sec";
	  }
	  else if (timer <= 0.0f && !doOnce){
	  	canCount=false;
		doOnce=true;
		timeText.text =  "Time left: 0.00 sec";
		timer = 0.0f;
	  }
     }

}


