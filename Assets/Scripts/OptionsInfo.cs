using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class OptionsInfo
{
	/// <summary>
	/// Language ID:
	/// 0 - English (default)
	/// 1 - Portuguese
	/// </summary>
	public int languageID;
	// Sound volume: 0..100
	public float soundEffectsVolume;
}

