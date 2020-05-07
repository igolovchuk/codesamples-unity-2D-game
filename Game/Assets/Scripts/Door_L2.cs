using UnityEngine;
using System.Collections;

public class Door_L2 : MonoBehaviour {

	
	Animator anim;
	void Start () {
		
		anim = GetComponent<Animator> ();
		
	}
	
	void Update()
	{
		if (Global.score == 300) {
			// If the player hits the trigger...
			//if (col.gameObject.tag == "Player") {
				
				anim.SetBool ("OffLock", true);
				
			//}
			
		}
	}

}
