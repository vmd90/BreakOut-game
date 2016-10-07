using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	public Vector3 speed;

	void Start()
	{
		speed = new Vector3(0, -2, 0);
	}

	void Update()
	{
		if (!MapManager.IsPaused) {
			transform.position += Time.deltaTime * speed;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Board") {
			if (name == "u")
				On1Up();
			else if (name == "f")
				OnFire();
			else if (name == "s")
				OnShrink();
			else if (name == "e")
				OnEnlarge();
			else if (name == "m")
				OnMultiply();

			Destroy(gameObject);
			MapManager.UpdateUI();
		}
		if (col.gameObject.name == "Down") { 
			Destroy(gameObject);
		}
	}

	void On1Up()
	{
		GameManager.Player.lives++;
	}

	void OnFire()
	{
		
	}

	void OnShrink()
	{

	}

	void OnEnlarge()
	{

	}

	void OnMultiply()
	{
		
	}
}
