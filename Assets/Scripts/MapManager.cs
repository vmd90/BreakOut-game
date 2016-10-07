using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using SimpleJSON;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
	public GameObject modalMapOptions;
	public static GameObject ball;
	public static Vector3 ballInitialPos;

	public Text score;
	public Text lives;
	public Animator animator;

	private static bool updateUI = true;
	private static bool restart = false;
	private static bool paused = false;
	private static bool respawn = false;

	// Use this for initialization
	void Start ()
	{
		ball = GameObject.Find("Ball");
		ballInitialPos = ball.transform.position;
		string mapName = "M"+ GameManager.MapNum;
		print(mapName);
		// Load map file
		Map.LoadFromJSON("Maps/"+mapName, gameObject);
		Pause();
	}

	void Update()
	{
		// if player still has lives left
		if (!GameManager.Player.IsAlive()) {
			SceneManager.LoadScene("GameOver");
		}
		// if player destroyed all blocks then load next level
		if (gameObject.transform.childCount <= 0) {
			Debug.Log("Won....");
			GameManager.NextMap();
			GameManager.LoadAfterLoadingScene("Map");
		}
		// restarting the whole level
		if (restart) {
			restart = false;
			GameManager.LoadAfterLoadingScene(SceneManager.GetActiveScene().name);
		}
		// if player's just died and still has lives
		if (respawn) {
			respawn = false;
			ball.transform.position = ballInitialPos;
			ball.GetComponent<Ball>().Restart();
			animator.Play("Ready");
		}
		// update the score, lives in UI
		if (updateUI) {
			score.text = "Score: " + GameManager.Player.score;
			lives.text = "Lives: " + GameManager.Player.lives;
			updateUI = false;
		}
	}

	public static void OnReadySetGoAnimationDone()
	{
		Debug.Log("Done");
		Unpause();
	}

	public static void UpdateUI()
	{
		updateUI = true;
	}

	public static bool IsPaused
	{
		get {
			return paused;
		}
	}

	public static void Respawn()
	{
		respawn = true;
		updateUI = true;
		Pause();
	}

	public static void Restart()
	{
		restart = true;
		updateUI = true;
	}

	public static void Pause()
	{
		paused = true;
		//Time.timeScale = 0f;
	}

	public static void Unpause()
	{
		paused = false;
		//Time.timeScale = 1f;
	}

	public void OnXButtonClicked()
	{
		modalMapOptions.SetActive(true);
	}
}
