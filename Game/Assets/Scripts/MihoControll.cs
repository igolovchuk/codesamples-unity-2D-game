using UnityEngine;
using System.Collections;

public class MihoControll : MonoBehaviour {


	public float maxSpeed = 8f;
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

	public bool falling = false;
	public LayerMask slippyGround;
	float fallingSpeed = 10;
	float fallingForce = 1000;
	public float acceleration = 30;		

	// додаєм аніматор
	void Start () {

		anim = GetComponent<Animator> ();
		Global.score = 0;
	

	}
	

	// Update is called once per frame
	void FixedUpdate () {

		falling = Physics2D.OverlapCircle (groundCheck.position, groundRadius, slippyGround);
		anim.SetBool ("Falling", falling);

		if(falling && grounded)
		{
			Debug.Log("falling!");
			//rigidbody2D.velocity = new Vector2 (fallingSpeed, rigidbody2D.velocity.y);
			rigidbody2D.AddForce(new Vector2(30,0));
		}
		else{
			
			//rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
		}


		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		anim.SetBool ("Ground", grounded);
		if (grounded)
						doubleJump = false;


		anim.SetFloat ("vSpeed",rigidbody2D.velocity.y);

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

		//
		if(!falling)
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
		/*
		if (falling) {
			
			fallingSpeed = IncrementTowards(fallingSpeed, 10, acceleration);
				}else{
			
			fallingSpeed = IncrementTowards(fallingSpeed, 0, acceleration);
		}*/

		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space)) {
		

			anim.SetBool("Ground", false);

			int i = Random.Range(0, jumpClips.Length);
			AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

			rigidbody2D.AddForce(new Vector2(fallingSpeed*50, jumpForce));

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

	// Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {
		if (n == target) {
			return n;	
		}
		else {
			//Mathf.Sign - Returns the sign of f.
			//Return value is 1 when f is positive or zero, -1 when f is negative.
			float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * dir;	
			return (dir == Mathf.Sign(target-n))? n: target; // if n has now passed target then return target, otherwise return n
		}
	}
}
