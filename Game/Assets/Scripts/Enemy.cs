using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public float moveSpeed = 2f;		
	public int HP = 2;					
	public Sprite deadEnemy;			
	public Sprite damagedEnemy;			
	public AudioClip[] deathClips;		
	public GameObject hundredPointsUI;	
	public float deathSpinMin = -100f;			
	public float deathSpinMax = 100f;			


	private SpriteRenderer ren;			
	private Transform frontCheck;		
	private bool dead = false;			
	private Score score;				

	
	void Awake()
	{
	
		frontCheck = transform.Find("frontCheck").transform;
		score = GameObject.Find("Score").GetComponent<Score>();
		ren = this.GetComponent<SpriteRenderer>();
	
	}

	void FixedUpdate ()
	{
		Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, 1);

		foreach(Collider2D c in frontHits)
		{
			if(c.tag == "Obstacle")
			{
				// фліпаєм сцука.
				Flip ();
				break;
			}
		}

		rigidbody2D.velocity = new Vector2(transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);	

		if(HP == 1 && damagedEnemy != null)
			ren.sprite = damagedEnemy;
			
		if (HP <= 0 && !dead) {
						Death ();
			//anim.SetBool("isDying", true);
			//moveSpeed = 0;
			//GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			//Invoke("Death", 2.0f);
				}
	}
	
	public void Hurt()
	{
		HP--;
	}
	
	void Death()
	{
		SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();

		foreach(SpriteRenderer s in otherRenderers)
		{
			s.enabled = false;
		}

		ren.enabled = true;
		ren.sprite = deadEnemy;

		// Increase the score by 100 points
		Global.score += 100;

		dead = true;

		rigidbody2D.fixedAngle = false;
		rigidbody2D.AddTorque(Random.Range(deathSpinMin,deathSpinMax));

		Collider2D[] cols = GetComponents<Collider2D>();
		foreach(Collider2D c in cols)
		{
			c.isTrigger = true;
		}

		int i = Random.Range(0, deathClips.Length);
		AudioSource.PlayClipAtPoint(deathClips[i], transform.position);

		Vector3 scorePos;
		scorePos = transform.position;
		scorePos.y += 1.5f;

		Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
	}


	public void Flip()
	{
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
