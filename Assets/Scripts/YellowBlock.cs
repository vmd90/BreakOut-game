using UnityEngine;
using System.Collections;

public class YellowBlock : Block
{
	public int state;

	void Start()
	{
		numStates = 2;
		state = 0;
	}
	/// <summary>
	/// Changes to the next state.
	/// </summary>
	/// <returns><c>true</c>, if state was changed, <c>false</c> otherwise.</returns>
	public override bool ChangeState()
	{
		Debug.Log("Change state");
		state++;
		if (state == 1) {
			GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/YellowBlockCracked");
		} else if (state > 1) {
			return false;
		}
		return true;
	}
}

