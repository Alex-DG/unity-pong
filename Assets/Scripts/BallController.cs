using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float startForce;

	private Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myRigidBody.velocity = new Vector2 (startForce, startForce);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
