using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float startForce;

	private Rigidbody2D myRigidBody;

	public GameObject paddle1;
	public GameObject paddle2;

	public GameManager gm;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myRigidBody.velocity = new Vector2 (startForce, startForce);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// Triggered when ball enters in the zone
	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "GoalZone") {

			// Ball enters in the area

			if (transform.position.x < 0) {
				// Ball enter in the GoalZone on the left reset the position of the ball next to the Paddle2 on the right
				transform.position = paddle2.transform.position + new Vector3 (-1f, 0, 0);
				myRigidBody.velocity = new Vector2 (-startForce, -startForce);

				gm.UpdateScore (2);

			} else {
				transform.position = paddle1.transform.position + new Vector3 (1f, 0, 0);
				myRigidBody.velocity = new Vector2 (startForce, startForce);

				gm.UpdateScore (1);
			}
		}
	}
}
