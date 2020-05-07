using UnityEngine;
using System.Collections;

public class EndThirdLevel1 : MonoBehaviour {
	
	public bool mainMenu = true;
	public bool about;
	public bool exit;
	public GUISkin MyGUISkin;
	public AudioClip clickSound;
	private Score scr;
	
	
	public Rigidbody2D rocket;				// Prefab of the rocket.
	// Reference to the PlayerControl script.
	
	
	//void Awake ()
	//{
	//rocket = GameObject.Find ("rocket").GetComponent<Rigidbody2D> ();
	//Setting up the reference.
	//playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	//en = transform.root.GetComponent<Enemy> ();
	//}
	
	
	void OnGUI() {
		//scr = this.GetComponent<Score>();
		GUILayout.BeginArea(new Rect(Screen.width/2-120, Screen.height/2-70, 200, 300), "");
		
		GUI.skin = MyGUISkin;
		
		GUILayout.Label("Level Completed");
		//GUILayout.Space(1);
		
		GUILayout.Label("Total Score: " + Global.score); //+ scr.score);
		//GUILayout.Space(1);
		//GUILayout.Label("1400");
		
		if(mainMenu == true) {
			if(GUILayout.Button("Next Level")) {
				audio.PlayOneShot(clickSound);

				BoxCollider2D[] cols = rocket.GetComponents<BoxCollider2D> ();
				foreach (BoxCollider2D c in cols) {
					c.isTrigger = true;
				}

				Application.LoadLevel(8);
				//Global.score = 0;
			}
			
			if(GUILayout.Button("Restart")) {
				audio.PlayOneShot(clickSound);
				
				BoxCollider2D[] cols = rocket.GetComponents<BoxCollider2D> ();
				foreach (BoxCollider2D c in cols) {
					c.isTrigger = false;
				}
				
				Application.LoadLevel(6);
				
				
				
				//about = true;
				//mainMenu = false;
			} 
			
			if(GUILayout.Button("Main menu")) {
				audio.PlayOneShot(clickSound);
				
				BoxCollider2D[] cols = rocket.GetComponents<BoxCollider2D> ();
				foreach (BoxCollider2D c in cols) {
					c.isTrigger = true;
				}
				
				//Application.Quit();
				Application.LoadLevel(1);
			}
		}
		
		
		GUILayout.EndArea();
	}
}
