using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : MonoBehaviour {

	[SerializeField]
	float objectDestroyLeftWayPointX = 0f;
	[SerializeField]
	float objectDestroyRightWayPointX = 0f;

	// Update is called once per frame
	void Update () {
		if (transform.position.x < objectDestroyLeftWayPointX) {
			Destroy (gameObject);
		}
		if (transform.position.x > objectDestroyRightWayPointX) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name.Equals ("Car")) {
			gameControlScript.instance.CarHit ();
		}
	}
}
