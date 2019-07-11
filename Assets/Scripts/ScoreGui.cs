using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGui : MonoBehaviour
{
	[SerializeField] private Text scoreText;
	[SerializeField] private Text score2Text;
	
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score black mage: " + Movement.count.ToString();
		score2Text.text = "Score purple mage: " + MovementPlayer2.count.ToString();
    }
}
