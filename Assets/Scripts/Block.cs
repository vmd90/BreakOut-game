using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
	public char type;
	public char item;
	protected int numStates = 1;

	public virtual bool ChangeState()
	{
		return true;
	}
}

