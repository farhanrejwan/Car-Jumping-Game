using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScript : MonoBehaviour {

	public GameObject gameObject;

	private gameControlScript gameControlScript;

	[SerializeField]
	float rotateSpeed = 0f;

	// Use this for initialization
	void Start () {
		gameControlScript = gameObject.GetComponent<gameControlScript> ();
	}

	// Update is called once per frame
	void Update () {
		if (!gameControlScript.gameStopped) {
			transform.Rotate (0, 0, rotateSpeed);
		}
	}
}
