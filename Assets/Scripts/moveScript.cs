using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour {

	float speedComparator = 0f;
	[SerializeField]
	float moveSpeed = 0f;
	[SerializeField]
	float leftWayPointX = 0f;
	[SerializeField]
	float rightWayPointX = 0f;

	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

		if (moveSpeed < speedComparator && transform.position.x < leftWayPointX) {
			transform.position += new Vector3 (2 * (rightWayPointX - 0), 0, 0);
		} else if (moveSpeed > speedComparator && transform.position.x > rightWayPointX) {
			transform.position += new Vector3 (2 * (leftWayPointX - 0), 0, 0);
		}
	}
}
