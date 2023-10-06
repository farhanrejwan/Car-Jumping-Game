using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peepScript : MonoBehaviour {

	int state = 0;
	float count = 0f;
	[SerializeField]
	float peepXPosition = 0f;
	[SerializeField]
	float peepYPosition = 0f;
	[SerializeField]
	float waitXPosition = 0f;
	[SerializeField]
	float waitYPosition = 0f;
	[SerializeField]
	float peepTimeLimit = 0f;
	[SerializeField]
	float waitTimeLimit = 0f;

	// Update is called once per frame
	void Update () {
		if (state == 0) {
			count += Time.deltaTime;

			if (count >= waitTimeLimit) {
				count = 0f;
				state = 1;
			}
		}

		if (state == 1) {
			transform.position = new Vector2 (peepXPosition, peepYPosition);
			state = 2;
		}

		if (state == 2) {
			count += Time.deltaTime;

			if (count >= peepTimeLimit) {
				count = 0f;
				state = 3;
			}
		}

		if (state == 3) {
			transform.position = new Vector2 (waitXPosition, waitYPosition);
			state = 0;
		}
	}
}
