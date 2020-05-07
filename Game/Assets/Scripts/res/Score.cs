using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
					// The player's score.
	

	//private Gun ju;
	private MihoControll playerControl;	// Reference to the player control script.
	//private int previousScore = 0;			// The score in the previous frame.


	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<MihoControll>();

	}




	void Update ()
	{

		// Set the score text.
		guiText.text = "Score: " + Global.score;

		// Set the previous score to this frame's score.
		//previousScore = score;
		
	
	}


	
}


