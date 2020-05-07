using UnityEngine;
using System.Collections;

public class Preview_move : MonoBehaviour {


	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.KeypadEnter)|| Input.GetKeyDown (KeyCode.Escape))
			Application.LoadLevel (1);

	}
}
