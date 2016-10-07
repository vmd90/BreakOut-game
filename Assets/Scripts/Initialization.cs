using UnityEngine;
using System.Collections;

public class Initialization : MonoBehaviour
{
	void Awake ()
	{
		// Initialize Game scripts
		GameManager.Initialize();
	}
}
