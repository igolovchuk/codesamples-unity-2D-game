using UnityEngine;
using System.Collections;

public class OpenChest : MonoBehaviour {

	Animator anim;
	void Start () {
		
		anim = GetComponent<Animator> ();
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			
			anim.SetBool ("OpenChest", true);

			
		}
	
		
	}
}
