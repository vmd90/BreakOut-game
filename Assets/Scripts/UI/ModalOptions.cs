using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalOptions : AbstModalWindow
{
	public override void SetVariables ()
	{
	}
    public override void AddEvents()
    {
        buttons["Cancel"].onClick.AddListener(Close);
        buttons["Save"].onClick.AddListener(Save);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Save()
    {
		GameManager.Options.soundEffectsVolume = contentPanel.transform.GetChild(3).GetComponent<Slider>().value;

		int languageID = contentPanel.transform.GetChild(2).GetComponent<Dropdown>().value;
		if (languageID != GameManager.Options.languageID)
        {
			GameManager.Options.languageID = languageID;
        }
		Close();
    }
}
