using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour
{
	private float translation;
	public float speed = 0.1f;
	
	// Update is called once per frame
	void Update ()
	{
		if (!MapManager.IsPaused) {
			translation = Input.GetAxis("Horizontal") * speed;
			transform.Translate(translation, 0, 0);
		}
	}
}
