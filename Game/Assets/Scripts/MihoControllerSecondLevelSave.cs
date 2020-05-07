using UnityEngine;
using System.Collections;

public class MihoControllerSecondLevelSave : MonoBehaviour {


	public float maxSpeed = 8f
	public float runSpeed = 18f;
	public bool facingRight = true;

	public AudioClip[] jumpClips;

	Animator anim;
	bool goRun = true;
	bool stopRun = false;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	bool doubleJump = false;
	bool doubleHuh = true;

	//private Transform platform;
	//private Vector3 platformPositionOld;
	//private Vector3 deltaPosition;

	void Start () {

		anim = GetComponent<Animator> ();
		Global.score = 0;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		if (grounded)
						doubleJump = false;


		anim.SetFloat ("vSpeed",rigidbody2D.velocity.y);

		//if(!grounded) return;

		//bool huh = (Input.GetButton ("Huh")) ? true : false;
		if(Input.GetButton("Huh"))
		anim.SetBool ("Huh", true);
		else if(Input.GetKeyDown(KeyCode.Backspace))
			anim.SetBool ("Huh", false);			
		float spp = (Input.GetButton("Run")) ? runSpeed:maxSpeed;
		bool runn = (Input.GetButton ("Run")) ? goRun : stopRun;
		anim.SetBool ("Run",runn);
		
						float move = Input.GetAxis ("Horizontal");
						anim.SetFloat ("Speed", Mathf.Abs (move));

		//platform = hit.platform;
		//platformPositionOld = platform.position;
		//else{platform = null;}
		//if(platform){deltaPosition = platform.position - platformPositionOld;}
		//else{deltaPosition = Vector3.zero;}
		rigidbody2D.velocity = new Vector2 (move * spp, rigidbody2D.velocity.y);
		//rigidbody2D.velocity = new Vector2 (move * spp+ deltaPosition.x, rigidbody2D.velocity.y);

		if (Input.GetKeyDown (KeyCode.Escape))
						Application.LoadLevel (1);


		if(move > 0 && !facingRight)
			Flip();
		else if(move < 0 && facingRight)
			Flip();
	}

	void Update(){

		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space)) {
		

			anim.SetBool("Ground", false);
			int i = Random.Range(0, jumpClips.Length);
			AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

			rigidbody2D.AddForce(new Vector2(0,jumpForce));
			if(!doubleJump && !grounded)
				doubleJump = true;

		}

	}

	void Flip ()	
	{

		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
