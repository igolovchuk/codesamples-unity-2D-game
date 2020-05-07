using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	private Vector3 start;
	private Vector3 end;
	private Vector3 bend;
	private float startTime;
	private float endTime = 5.0f; //how long we want it to take to go from start to end in seconds
	private float elapsedTime = 0.0f; //how much time has elapsed since we started
	// Use this for initialization
	void Start () {

						start = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
						end = new Vector3 (transform.position.x - 15.0f, transform.position.y, transform.position.z);

						startTime = Time.time; //Need to grab the initial time we start to move
		
				
		
	}
	
	// Update is called once per frame
	void Update () {

						//Time.time returns how much time has passed since the start of the program.
						elapsedTime = Time.time - startTime; //We'll accumulate how much time passes each frame(you could also just keep adding Time.deltaTime to elapsedTime instead, I'm just used to keeping a start time of something)
						//here we'll make sure the value between how much time has elapsed and how much time we want to take overall is converted to a 0 to 1 range
						float lerp_elapsed_time = elapsedTime / endTime;
						//Just need our start position, our end position and our elapsed time to overall time ratio.

						transform.position = Vector3.Lerp (start, end, lerp_elapsed_time);
	//	transform.Translate(Vector3.left.Lerp(start, end, lerp_elapsed_time) * Time.deltaTime);
				
		
	}



}
