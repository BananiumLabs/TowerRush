using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;

///Code for the Options submenu in the Main Menu.
public class Options : MonoBehaviour {

	public Slider volume;
	public Dropdown dropdown;
	public Text volumeValue, fullscreenLabel;
	public Canvas generalPanel, controlsPanel, optionsMenu, mainMenu;
	public Dropdown graphics, resolution;
	public Button fullscreenButton;
	public bool fullscreen;
	
	public InputManager controls;

	protected string optionsPath;
	protected string[] defaultOptions = {"50", "true", "3", "0"};
	
	void Start () {
		controls.configPath = Vars.path + "/controls.cfg";
		optionsPath = Vars.path + "/options.cfg";

		volume.maxValue = 100;
		volume.minValue = 0;
		volume.wholeNumbers = true;
		

		generalPanel.transform.Rotate (20.0f, 0.0f, 0.0f);
		
		ReadConfig();
		UpdateValues();
	}

	void Update() {
		if(optionsMenu.enabled) UpdateValues();
	}

	public void UpdateValues () {
		
		fullscreenLabel.text = (Screen.fullScreen) ? "Enabled" : "Disabled";
		if(Input.GetKey(KeyCode.F11)) fullscreenToggle();
		
		try {
			if(Screen.width > 1300) mainMenu.scaleFactor = 2;
			else if(Screen.width < 700) mainMenu.scaleFactor = .5f;
			else mainMenu.scaleFactor = 1;
		} catch {}
			
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

		//Screen resolution
		switch (resolution.value) {
		case 0: //auto
			Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,fullscreen);
			break;
		case 1: //1920x1200
			Screen.SetResolution(1920,1200,fullscreen);
			break;
		case 2: //1920x1080
			Screen.SetResolution(1920,1080,fullscreen);
			break;
		case 3: //1366x768
			Screen.SetResolution(1366,768,fullscreen);
			break;
		case 4: //1280x1024
			Screen.SetResolution(1280,1024,fullscreen);
			break;
		case 5: //1024x768
			Screen.SetResolution(1024,768,fullscreen);
			break;
		}
			
	}

	//when "reset to default" is pressed
	public void resetOptions() {
		if(generalPanel.enabled) {
			resetOptions(true);

		} else if(controlsPanel.enabled) {
			controls.WriteDefaultControls();
		}

		UpdateValues();
		
	}

	//Allows for resetting of options from within code
	protected void resetOptions(bool usingCode) {
		if(usingCode) {
			graphics.value = 4;
			volume.value = 50;
			resolution.value = 0;
			WriteConfig();
			UpdateValues();
		} else resetOptions();
	}

	public void WriteConfig() {
		using (var writer = new StreamWriter(File.Create(optionsPath))) {
			writer.WriteLine(volume.value);
			writer.WriteLine(fullscreen);
			writer.WriteLine(graphics.value);
			writer.WriteLine(resolution.value);
			Debug.Log("Wrote options");
		}
	}


	public void ReadConfig() {
		try {
			string[] tempOptions = File.ReadAllLines(optionsPath);
			volume.value = Int32.Parse(tempOptions[0]);
			fullscreen = Boolean.Parse(tempOptions[1]);
			graphics.value = Int32.Parse(tempOptions[2]);
			resolution.value = Int32.Parse(tempOptions[3]);
			Debug.Log("Successfully loaded options file");
		} catch (Exception e) {
			Debug.LogWarning("Error when reading config file: " + e);
			resetOptions(true);
		}
	}

	public void CloseOptions() {
		optionsMenu.enabled = false;
		WriteConfig();
	}
	
	public void fullscreenToggle() {
		fullscreen = !fullscreen;
		UpdateValues();
	}
}