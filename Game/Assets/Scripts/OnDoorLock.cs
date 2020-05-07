using UnityEngine;
using System.Collections;

public class OnDoorLock : MonoBehaviour {

	Animator anim;
	void Start () {
		
		anim = GetComponent<Animator> ();
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (Global.score == 300) {
						// If the player hits the trigger...
						if (col.gameObject.tag == "Player") {

								anim.SetBool ("OffLock", true);
		
						}
				}
				
	}
	


}
