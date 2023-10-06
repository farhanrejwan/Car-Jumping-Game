using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameControlScript : MonoBehaviour {

	public static gameControlScript instance = null;

	[SerializeField]
	GameObject restartButton;

	[SerializeField]
	Text highScoreText;

	[SerializeField]
	Text yourScoreText;

	[SerializeField]
	GameObject[] obstacles;

	[SerializeField]
	Transform spawnPoint;

	[SerializeField]
	float timeToBoost = 0f;
	float nextBoost;

	float spawnRate = 0f;
	float nextSpawn;

	int highScore = 0;
	int yourScore = 0;

	public static bool gameStopped;

	float nextScoreIncrease = 0f;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		restartButton.SetActive (false);
		yourScore = 0;
		gameStopped = false;
		Time.timeScale = 1f;
		highScore = PlayerPrefs.GetInt ("highScore");
		nextSpawn = Time.time + spawnRate;
		nextBoost = Time.unscaledTime + timeToBoost;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStopped) {
			IncreaseYourScore ();
		}

		highScoreText.text = "High Score : " + highScore;
		yourScoreText.text = "Your Score : " + yourScore;

		if (Time.time > nextSpawn) {
			SpawnObstacle ();
		}

		if (Time.unscaledTime > nextBoost && !gameStopped) {
			BoostTime ();
		}
	}

	public void CarHit () {
		if (yourScore > highScore) {
			PlayerPrefs.SetInt ("highScore", yourScore);
		}

		Time.timeScale = 0;
		gameStopped = true;
		restartButton.SetActive (true);
	}

	void SpawnObstacle () {
		spawnRate = Random.Range (2, 5);
		nextSpawn = Time.time + spawnRate;
		int randomObstacle = Random.Range (0, obstacles.Length);
		Instantiate (obstacles [randomObstacle], spawnPoint.position, Quaternion.identity);
	}

	void BoostTime () {
		nextBoost = Time.unscaledTime + timeToBoost;
		Time.timeScale += 0.01f;
	}

	void IncreaseYourScore () {
		if (Time.unscaledTime > nextScoreIncrease) {
			yourScore += 1;
			nextScoreIncrease = Time.unscaledTime + 0.25f;
		}
	}

	public void RestartGame () {
		SceneManager.LoadScene ("Play");
	}
}
