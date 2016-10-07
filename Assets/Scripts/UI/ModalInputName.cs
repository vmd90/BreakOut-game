using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ModalInputName : AbstModalWindow
{
	public override void SetVariables()
	{
	}

	public override void AddEvents()
	{
		buttons["Cancel"].onClick.AddListener(Close);
		buttons["Play"].onClick.AddListener(StartGame);
	}

	public void Close()
    {
        gameObject.SetActive(false);
    }

	public void StartGame()
	{
		InputField name = GetComponentInChildren<InputField>();
		GameManager.Player.Set(name.text);
		Close();
		GameManager.MapNum = 1;
		GameManager.LoadAfterLoadingScene("Map");
	}
}