using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Map
{
	public const char RED = 'r';
	public const char BLUE = 'b';
	public const char YELLOW = 'y';

	public const char I_1UP = 'u';
	public const char I_FIRE = 'f';
	public const char I_SHRINK = 's';
	public const char I_ENLARGE = 'e';
	public const char I_MULTIPLY = 'm';
	public const char NONE = '-';
	private static Vector2 offset = new Vector2(1.6f, -0.8f);
	/// <summary>
	/// Loads map from JSON file.
	/// </summary>
	/// <param name="path">Path of the file.</param>
	/// <param name="parent">Parent node to add all objects from file to.</param>
	public static void LoadFromJSON(string path, GameObject parent)
	{
		TextAsset jsonFile = Resources.Load<TextAsset>(path);
		JSONNode json = JSON.Parse(jsonFile.text);
		JSONArray map = json["map"].AsArray;
		JSONArray items = json["items"].AsArray;
		// Instantiating blocks
		float x, y;
		y = CameraLimits.Max.y - 1.2f; // Starting from up to down

		for(int i = 0; i < map.Count; ++i) {
			x = CameraLimits.Min.x + 1.0f; // Left to right
			string m = map[i];
			string e = items[i];
			for (int j = 0; j < m.Length; ++j) {
				GameObject block = null;
				bool none = false;
				switch (m[j])
				{
					case RED:
						block = CreateBlock("RedBlock", new Vector3(x, y), parent);
						break;
					case BLUE:
						block = CreateBlock("BlueBlock", new Vector3(x, y), parent);
						break;
					case YELLOW:
						block = CreateBlock("YellowBlock", new Vector3(x, y), parent);
						break;
					default: // NONE
						none = true;
						break;
				}
				if (!none) {
					block.GetComponent<Block>().type = m[j];
					block.GetComponent<Block>().item = e[j];
				}
				x += offset.x;
			}
			y += offset.y;
		}
	}

	public static GameObject CreateBlock(string name, Vector3 pos, GameObject parent)
	{
		GameObject gobj = GameManager.CreateSprite(name, "Sprites/" + name, pos, parent);
		gobj.transform.localScale = new Vector3(0.8f, 1, 1);

		if (name == "YellowBlock") {
			gobj.tag = "HardBlock";
			gobj.AddComponent<YellowBlock>();
		} else {
			gobj.tag = "Block";
			gobj.AddComponent<Block>();
		}
		BoxCollider2D b = gobj.AddComponent<BoxCollider2D>();
		b.isTrigger = true;
		b.size = new Vector2(1.7f, 0.6f);
		EdgeCollider2D e = gobj.AddComponent<EdgeCollider2D>();
		e.isTrigger = true;
		e.points = new Vector2[]{ new Vector2(-0.9f,0.25f), new Vector2(-0.9f,-0.25f) };
		EdgeCollider2D e2 = gobj.AddComponent<EdgeCollider2D>();
		e2.isTrigger = true;
		e2.points = new Vector2[]{ new Vector2(0.9f,0.25f), new Vector2(0.9f,-0.25f) };
		return gobj;
	}

	public static GameObject CreateItem(string name, Vector3 pos, GameObject parent)
	{
		GameObject gobj = GameManager.CreateSprite(name, "Sprites/" + name, pos, parent);
		gobj.tag = "Item";
		gobj.AddComponent<Item>();
		BoxCollider2D b = gobj.AddComponent<BoxCollider2D>();
		b.isTrigger = true;
		Rigidbody2D rb = gobj.AddComponent<Rigidbody2D>();
		rb.isKinematic = true;
		return gobj;
	}

	public static int GetPointsFromBlock(GameObject block)
	{
		int p = 0;
		char c = block.GetComponent<Block>().type;
		switch (c)
		{
			case RED:
				p = 5;
				break;
			case BLUE:
				p = 8;
				break;
			case YELLOW:
				p = 10;
				break;
		}
		return p;
	}
}

