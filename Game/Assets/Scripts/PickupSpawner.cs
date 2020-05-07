using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour
{
	public GameObject[] pickups;				// Array of pickup prefabs with the bomb pickup first and health second.
	public float pickupDeliveryTime = 5f;		// Delay on delivery.
	public Transform target;
	//public float speeddd = 0.002f;
	private Score scrr;

	//private PlayerHealth playerHealth;
	//private Score score;
	//private Enemy en;


	//void Awake ()
	//{
		// Setting up the reference.
	//	playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	//	score = GameObject.Find("Score").GetComponent<Score>();
	//	en = transform.root.GetComponent<Enemy> ();
	//}


	void Start ()
	{

						//Fall ();
		//scrr = GameObject.Find ("Score").GetComponents<Score> ();

						StartCoroutine (DeliverPickup ());
			
	}


	/*void Fall(){

		if (Global.score > 0) {
						//float dropPosX = Random.Range (-15f, 15f);
		
						// Create a position with the random x coordinate.
						//Vector3 dropPos = new Vector3 (15f, 15f, 1f);
        
			transform.position = new Vector3(-10f, 15f, 1f); 
			//pickups[0].transform.position.y += speeddd;
			//transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);
						// ... instantiate a random pickup at the drop position.
						//int pickupIndex = Random.Range (0, pickups.Length);
				Instantiate (pickups [0], transform.position, Quaternion.identity);	
					
	                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
				}


	}*/
	
	public IEnumerator DeliverPickup()
	{
		               
						// Wait for the delivery delay.
						yield return new WaitForSeconds (pickupDeliveryTime);

						// Create a random x coordinate for the delivery in the drop range.
						float dropPosX = Random.Range (-15f, 15f);

						// Create a position with the random x coordinate.
						Vector3 dropPos = new Vector3 (dropPosX, 15f, 1f);

						// ... instantiate a random pickup at the drop position.
						//int pickupIndex = Random.Range (0, pickups.Length);
						Instantiate (pickups [0], dropPos, Quaternion.identity);
				
				
				
				
	}

}
