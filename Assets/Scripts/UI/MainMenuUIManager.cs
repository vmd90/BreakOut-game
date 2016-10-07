using UnityEngine;
using System.Collections;

public class MainMenuUIManager : MonoBehaviour {

	public GameObject modalInputName;
    public GameObject modalOptions;

	public void OnPlayButtonClicked()
	{
		modalInputName.SetActive(true);
	}

	public void OnOptionsClicked()
	{
        modalOptions.SetActive(true);
	}

	public void OnExitClicked()
	{
	#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
	#else
		Application.Quit();
	#endif
	}
}
