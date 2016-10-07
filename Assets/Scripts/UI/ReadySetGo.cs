using UnityEngine;
using System.Collections;

public class ReadySetGo : MonoBehaviour {

	public void OnAnimationDone()
	{
		MapManager.OnReadySetGoAnimationDone();
	}
}
