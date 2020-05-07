using UnityEngine;
using System.Collections;

public class EndSecLev : MonoBehaviour {

	
	//public GameObject splash;
	public Rigidbody2D rocket;
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (Global.score == 300) {
						// If the player hits the trigger...
						if (col.gameObject.tag == "Player") {
								// .. stop the camera tracking the player
								GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraFollow> ().enabled = false;
			
								//	BoxCollider2D cols = rocket.GetComponents<BoxCollider2D> ();
								//rocket.GetComponents<BoxCollider2D>();
			
			
			
								// .. stop the Health Bar following the player
								if (GameObject.FindGameObjectWithTag ("HealthBar").activeSelf) {
										GameObject.FindGameObjectWithTag ("HealthBar").SetActive (false);
								}
			
								//guiText.text = "Score: ";
			
								Debug.Log ("Completed");
			
			
								Destroy (col.gameObject);
								Application.LoadLevel (5);
								// ... reload the level.
								//StartCoroutine("ReloadGame");
						} else {
			
								// Destroy the enemy.
								Destroy (col.gameObject);	
						}
				}
	}
	
	
	IEnumerator ReloadGame()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(2);
		// ... and then reload the level.
		Application.LoadLevel(Application.loadedLevel);
	}
}
