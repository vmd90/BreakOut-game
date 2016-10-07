using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ModalMapOptions : AbstModalWindow
{
	public void OnEnable()
	{
		MapManager.Pause();
	}

	public void OnDisable()
	{
		MapManager.Unpause();
	}

	public override void SetVariables()
	{
	}

	public override void AddEvents()
	{
		buttons["Continue"].onClick.AddListener(Continue);
		buttons["Restart"].onClick.AddListener(Restart);
		buttons["GoToMenu"].onClick.AddListener(GoToMenu);
	}

	public void Close()
	{
		gameObject.SetActive(false);
	}

	public void Continue()
	{
		Close();
	}

	public void Restart()
	{
		Close();
		MapManager.Restart();
	}

	public void GoToMenu()
	{
		GameManager.Player.Set();
		Close();
		SceneManager.LoadScene("MainMenu");
	}
}
