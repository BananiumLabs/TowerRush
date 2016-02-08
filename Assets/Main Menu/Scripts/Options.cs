using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Options : MonoBehaviour {

	public Slider volume;
	public Dropdown dropdown;
	public Text volumeValue;
	public Canvas generalPanel;
	public Canvas controlsPanel;
	public Dropdown graphics;

	void Start () {
		
		volume = volume.GetComponent<Slider> ();
		dropdown = dropdown.GetComponent<Dropdown> ();
		volumeValue = volumeValue.GetComponent<Text> ();
		generalPanel = generalPanel.GetComponent<Canvas> ();
		controlsPanel = controlsPanel.GetComponent<Canvas> ();
		graphics = graphics.GetComponent<Dropdown> ();

		volume.maxValue = 100;
		volume.minValue = 0;
		volume.wholeNumbers = true;

		generalPanel.transform.Rotate (20.0f, 0.0f, 0.0f);
	
	}
	
	// Update is called once per frame
	void Update () {

		AudioListener.volume = volume.value / 100;

		volumeValue.text = volume.value.ToString ();

		if(dropdown.value == 0) {
			generalPanel.enabled = true;
			controlsPanel.enabled = false;
		}  else if(dropdown.value == 1) {
			generalPanel.enabled = false;
			controlsPanel.enabled = true;
		}

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
			
	}

	public void resetOptions() {
		graphics.value = 4;
		volume.value = 50;
	}
}