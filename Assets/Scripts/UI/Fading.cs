using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour
{
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;
	private float alpha = 1;
	private int fadeDir = -1;  // direction to fade: in = -1 and out = 1

	void Awake()
	{
		SceneManager.sceneLoaded += delegate {
			BeginFade(-1);
		};
		SceneManager.sceneUnloaded += delegate {
			BeginFade(1);
		};
	}

	void OnGUI()
	{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		// color
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	// set the direction to fade
	public float BeginFade(int direction)
	{
		fadeDir = direction;
		return fadeSpeed;
	}

	// called when a level is loaded
//	void OnLevelWasLoaded()
//	{
//		BeginFade(-1); // fade in
//	}
}