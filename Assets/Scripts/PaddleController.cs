﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	public float speed;
	public float direction; // Paddle direction : 1 going up, -1 going down, 0 going anywhere
	public float adjustSpeed;

	public Transform upperLimit;
	public Transform lowerLimit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Paddle movement
		if (Input.GetKey(KeyCode.W)) {
			// Up
			transform.position = new Vector3 (
				transform.position.x, 
				transform.position.y + (speed * Time.deltaTime),
				transform.position.z);

			direction = 1;
		} else if (Input.GetKey(KeyCode.S)) {
			// Down
			transform.position = new Vector3 (
				transform.position.x, 
				transform.position.y - (speed * Time.deltaTime),
				transform.position.z);

			direction = -1;
		} else {
			direction = 0;
		}

		// Check the limit position of the paddle
		if (transform.position.y > upperLimit.position.y) {
			// Upper limit
			transform.position = new Vector3 (transform.position.x, upperLimit.position.y, transform.position.z);
		} else if (transform.position.y < lowerLimit.position.y) {
			// Lower limit
			transform.position = new Vector3 (transform.position.x, lowerLimit.position.y, transform.position.z);
		}
			
	}

	// Ball no longer touching a paddle
	// Used to make the ball speed up and add some velocity when the direction of the ball changes
	// it adds some difficulty to the game
	// x velocity will be faster and faster after the end of collision by * 1.1f
	void OnCollisionExit2D(Collision2D other) {
		other.rigidbody.velocity = new Vector2 (
			other.rigidbody.velocity.x * 1.1f, 
			other.rigidbody.velocity.y + (direction * adjustSpeed));
	}
}
