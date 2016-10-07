using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
	public Vector3 speed;

	void Start()
	{
		Restart();
	}

	void Update()
	{
		if (!MapManager.IsPaused) {
			transform.position += Time.deltaTime * speed;
		}
	}

	public void Restart()
	{
		Random.InitState((int)System.DateTime.Now.Ticks);
		speed = new Vector3();
		int n = Random.Range(0, 100);
		speed.x = (n % 2 == 0 ? 1.0f : -1.0f) + Random.Range(1f, GameManager.MapNum); 
		speed.y = Random.Range(2.5f, 5.0f) + Random.Range(1f, GameManager.MapNum);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject gobj = col.gameObject;
		if (gobj.tag == "Block") {
			// Update UI
			MapManager.UpdateUI();
			ParticleSystem p = GameObject.FindObjectOfType<ParticleSystem>();
			p.transform.position = gobj.transform.position;
			p.Play();
			// Increase score and destroy block
			GameManager.Player.score += Map.GetPointsFromBlock(col.gameObject);
			Destroy(gobj);

			BoxCollider2D b = gobj.GetComponent<BoxCollider2D>();
			Vector2 m = Random.insideUnitCircle;
			if (col == b) { // move up or down
				speed.y = -speed.y;
				speed.y = speed.y > 0 ? speed.y + m.y : speed.y - m.y;
			} else {  // move left or right
				speed.x = -speed.x;
				speed.x = speed.x > 0 ? speed.x + 2*m.x : speed.x - 2*m.x;
			}
			// If there is an item
			char item = gobj.GetComponent<Block>().item;
			if (item != Map.NONE) {
				Map.CreateItem(item.ToString(), gobj.transform.position, gobj.transform.parent.gameObject);
			}

		} else if(gobj.tag == "HardBlock") {

			if (!gobj.GetComponent<Block>().ChangeState()) {
				MapManager.UpdateUI();
				ParticleSystem p = GameObject.FindObjectOfType<ParticleSystem>();
				p.transform.position = gobj.transform.position;
				p.Play();
				// Increase score and destroy block
				GameManager.Player.score += Map.GetPointsFromBlock(col.gameObject);
				Destroy(gobj);

				// If there is an item
				char item = gobj.GetComponent<Block>().item;
				if (item != Map.NONE) {
					Map.CreateItem(item.ToString(), gobj.transform.position, gobj.transform.parent.gameObject);
				}
			}

			BoxCollider2D b = gobj.GetComponent<BoxCollider2D>();
			if (col == b) { // move up or down
				speed.y = -speed.y;
			} else {  // move left or right
				speed.x = -speed.x;
			}

		} else if (gobj.tag == "Board") {
			// Change direction
			speed.y = -speed.y + Random.Range(-0.5f, 0.5f);
			speed.x = speed.x + Random.Range(0f, 0.7f);
		} else if (gobj.name == "Left" || gobj.name == "Right") {
			speed.x = -speed.x;
		} else if (gobj.name == "Up") {
			speed.y = -speed.y;
		} else if (gobj.name == "Down") {
			// Die!
			GameManager.Player.LoseLife();
			MapManager.UpdateUI();
			MapManager.Respawn();
		}
	}
}

