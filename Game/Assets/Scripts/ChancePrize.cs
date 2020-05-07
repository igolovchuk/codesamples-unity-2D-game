using UnityEngine;
using System.Collections;

public class ChancePrize : MonoBehaviour {


	private Score sc;		// Reference to the PlayerControl script.
	private Animator anim;
	private MihoControll playerCtrl;


	void Awake(){
		anim = transform.root.gameObject.GetComponent<Animator>();
		sc = transform.root.GetComponent<Score> ();
		playerCtrl = transform.root.GetComponent<MihoControll>();
	}
	// Use this for initialization
	void Update () {
		if (Input.GetKey(KeyCode.G)) {
			anim.SetBool("Prize",true);

		}

	
	}
	

}
