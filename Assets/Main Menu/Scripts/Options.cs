using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//SUMMARY: Code for the Options submenu in the Main Menu.
public class Options : MonoBehaviour {

	public Slider volume;
	public Dropdown dropdown;
	public Text volumeValue;
	public Canvas generalPanel;
	public Canvas controlsPanel;
	public Canvas optionsMenu;
	public Dropdown graphics;
	public Dropdown uiSize;

	public Canvas mainMenu;

	void Start () {
		
		volume = volume.GetComponent<Slider> ();
		dropdown = dropdown.GetComponent<Dropdown> ();
		volumeValue = volumeValue.GetComponent<Text> ();
		generalPanel = generalPanel.GetComponent<Canvas> ();
		controlsPanel = controlsPanel.GetComponent<Canvas> ();
		graphics = graphics.GetComponent<Dropdown> ();
		uiSize = uiSize.GetComponent<Dropdown> ();
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		mainMenu = mainMenu.GetComponent<Canvas> ();

		volume.maxValue = 100;
		volume.minValue = 0;
		volume.wholeNumbers = true;

		generalPanel.transform.Rotate (20.0f, 0.0f, 0.0f);
		
		if(Screen.width > 1300) uiSize.value = 2;
		else if(Screen.width < 800) uiSize.value = 0;
		else uiSize.value = 1;
	
	}

	void Update () {

		AudioListener.volume = volume.value / 100;

		volumeValue.text = volume.value.ToString ();

		//Which panel is active
		if(dropdown.value == 0 && optionsMenu.enabled) {
			generalPanel.enabled = true;
			controlsPanel.enabled = false;
		}  else if(dropdown.value == 1) {
			generalPanel.enabled = false;
			controlsPanel.enabled = true;
		}

		//Graphics setting
		switch (graphics.value) {
		case 0:
			QualitySettings.SetQualityLevel (1, true);
			break;
		case 1:
			QualitySettings.SetQualityLevel (2, true);
			break;
		case 2:
			QualitySettings.SetQualityLevel (3, true);
			break;
		case 3:
			QualitySettings.SetQualityLevel (4, true);
			break;
		case 4:
			QualitySettings.SetQualityLevel (5, true);
			break;
		case 5:
			QualitySettings.SetQualityLevel (6, true);
			break;

		}

		//UI Size setting
		switch (uiSize.value) {
		case 0:
			mainMenu.scaleFactor = 0.5f;
			break;
		case 1:
			mainMenu.scaleFactor = 1f;
			break;
		case 2:
			mainMenu.scaleFactor = 1.5f;
			break;
		}
			
			
	}

	//when "reset to default" is pressed
	public void resetOptions() {
		graphics.value = 4;
		volume.value = 50;
		uiSize.value = 1;
	}
}