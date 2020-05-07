using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	
	public float xMargin = 1f;		// Distance in the x axis the player can move before the camera follows.
	public float yMargin = 1f;		// Distance in the y axis the player can move before the camera follows.

	public float xSmooth = 8f;		// How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 8f;		// How smoothly the camera catches up with it's target movement in the y axis.

	public Vector2 maxXAndY;		// The maximum x and y coordinates the camera can have.
	public Vector2 minXAndY;		// The minimum x and y coordinates the camera can have.


	private Transform player;		// Reference to the player's transform.


	void Awake ()
	{
		// Setting up the reference.
		//FindGameObjectWithTag - Returns a list of active GameObjects tagged tag. Returns empty array if no GameObject was found.
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}


	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}


	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}


	//This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	//FixedUpdate should be used instead of Update when dealing with Rigidbody. 
		//For example when adding a force to a rigidbody, 
		//you have to apply the force every fixed frame inside FixedUpdate 
		//instead of every frame inside Update.
	void FixedUpdate ()
	{
		TrackPlayer();
	}
	
	
	void TrackPlayer ()
	{
		
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;

	
		// If the player has moved beyond the x margin...
		if(CheckXMargin())
				//Mathf.Lerp - Interpolates between a and b by t. t is clamped between 0 and 1.
				//When t = 0 returns from. When t = 1 return to. When t = 0.5 returns the average of a and b.
			// ... тоді нова позиція камери по х має плавно наближатись до позиції гравця по х
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);

		
		// If the player has moved beyond the y margin...
		if(CheckYMargin())
			// ... то наближаємо координату камери по у до гравця
			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);

		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);


		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
