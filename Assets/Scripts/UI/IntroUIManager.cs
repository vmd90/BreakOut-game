using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroUIManager : MonoBehaviour
{
	public void OnStartClicked()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
