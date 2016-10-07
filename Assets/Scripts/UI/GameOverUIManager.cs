using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour
{
	public void OnNoClicked()
	{
		GameManager.LoadAfterLoadingScene("MainMenu");
	}

	public void OnYesClicked()
	{
		GameManager.Player.Set(3, 0);
		GameManager.LoadAfterLoadingScene("M1");
	}
}
