using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class AbstModalWindow : MonoBehaviour {

	protected GameObject windowPanel;
	protected GameObject contentPanel;
	protected GameObject buttonsPanel;

	//protected Button[] buttons;
	protected Dictionary<string, Button> buttons;
	protected Text message;

	void Start()
	{
		windowPanel = transform.GetChild(0).gameObject;
		contentPanel = windowPanel.transform.GetChild(0).gameObject;
		buttonsPanel = windowPanel.transform.GetChild(1).gameObject;

		message = contentPanel.transform.GetChild(1).GetComponent<Text>();

		buttons = new Dictionary<string, Button>();
		for (int i = 0; i < buttonsPanel.transform.childCount; ++i) {
			GameObject b = buttonsPanel.transform.GetChild(i).gameObject;
			buttons.Add(b.name, b.GetComponent<Button>());
		}

		SetVariables();
		AddEvents();
	}

	public abstract void SetVariables();

	public abstract void AddEvents();

}
