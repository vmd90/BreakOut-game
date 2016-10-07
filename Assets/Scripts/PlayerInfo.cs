using UnityEngine;
using System.Collections;
using System;

public class PlayerInfo
{
	public string name;
	public int lives;
	public int score;

	public PlayerInfo() 
	{
		Set();
	}

	public void Set(int lives, int score)
	{
		this.lives = lives;
		this.score = score;
	}

	public void Set(string name = "", int lives = 3) {
		this.name = name;
		this.lives = lives;
		this.score = 0;
	}

	public void LoseLife()
	{
		lives--;
		if (lives <= 0) {
			lives = 0;
			Debug.Log("Died");
		}
	}

	public bool IsAlive()
	{
		return lives > 0;
	}
}

