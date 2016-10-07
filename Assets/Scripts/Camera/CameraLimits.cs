using UnityEngine;
using System.Collections;

public class CameraLimits
{
	// 5 - 9, 7 - 12
	public static Vector2 Min
	{
		get {
			return new Vector2(-9, -5);
		}
	}

	public static Vector2 Max
	{
		get {
			return new Vector2(9, 5);
		}
	}
}

