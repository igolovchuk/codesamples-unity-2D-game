using UnityEngine;
using System.Collections;

public class Kill2Level : MonoBehaviour {

	public GameObject splash;
	public Rigidbody2D rocket;
	
	
	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			// .. stop the camera tracking the player
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
			
			// .. stop the Health Bar following the player
			if(GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
			{
				GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
			}
			
			// ... instantiate the splash where the player falls in.
			Instantiate(splash, col.transform.position, transform.rotation);
			// ... destroy the player.
			
			
			
			Destroy (col.gameObject);
			
			BoxCollider2D[] cols = rocket.GetComponents<BoxCollider2D> ();
			foreach (BoxCollider2D c in cols) {
				c.isTrigger = false;
			}
			
			// ... reload the level.
			StartCoroutine("ReloadGame");
		}
		else
		{
			// ... instantiate the splash where the enemy falls in.
			Instantiate(splash, col.transform.position, transform.rotation);
			
			// Destroy the enemy.
			Destroy (col.gameObject);	
		}
		
	}
	
	
	IEnumerator ReloadGame()
	{			
				// ... pause briefly
				yield return new WaitForSeconds (2);
				// ... and then reload the level.
				Application.LoadLevel (Application.loadedLevel);
		}
}
