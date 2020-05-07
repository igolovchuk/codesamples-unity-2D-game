using UnityEngine;
using System.Collections;

public class ScoreTrigger : MonoBehaviour {

	public GameObject hundredPointsUI;	
	//private Score score;				// Reference to the Score script.
	public GameObject scoress;	


	void OnTriggerEnter2D(Collider2D col)
	{

		// If the player hits the trigger...
		if (col.gameObject.tag == "Player") {

			BoxCollider2D[] cols = scoress.GetComponents<BoxCollider2D> ();
			foreach (BoxCollider2D c in cols) {
				c.isTrigger = false;
			}

			Global.score += 100;

			Debug.Log(Global.score);

			Vector3 scorePos;
			scorePos = transform.position;
			scorePos.y += 1.5f;
			Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
		}
		}

}
