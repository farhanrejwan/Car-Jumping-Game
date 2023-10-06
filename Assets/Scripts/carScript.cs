using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class carScript : MonoBehaviour {

	Rigidbody2D rb;
	[SerializeField]
	float jumpForce = 0f;
	float spaceBar;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		spaceBar = CrossPlatformInputManager.GetAxisRaw ("Jump");
	}

	void FixedUpdate () {
		if (spaceBar > 0 && rb.velocity.y < 0.1 && rb.position.y <-1) {
			rb.AddForce (Vector2.up * jumpForce);
		}
	}
}
