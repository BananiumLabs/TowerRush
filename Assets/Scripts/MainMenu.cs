using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Button play;
	public Button option;
	public Button exit;

	public Button closeOptions;
	public Text optionHeader;
	public Canvas options;

	public Button closeLevelSelect;
	public Text levelSelectText;
	public Canvas LevelSelect;

	// Use this for initialization
	void Start () {
		closeOptions = closeOptions.GetComponent<Button> ();
		optionHeader = optionHeader.GetComponent<Text> ();
		options = options.GetComponent<Canvas> ();

		play = play.GetComponent<Button> ();
		option = option.GetComponent<Button> ();
		exit = exit.GetComponent<Button> ();

		closeLevelSelect = closeLevelSelect.GetComponent<Button> ();
		levelSelectText = levelSelectText.GetComponent<Text> ();
		LevelSelect = LevelSelect.GetComponent<Canvas> ();

		play.enabled = true;
		option.enabled = true;
		exit.enabled = true;

		options.enabled = false;
		optionHeader.enabled = false;
		closeOptions.enabled = false;

		LevelSelect.enabled = false;
		levelSelectText.enabled = false;
		closeLevelSelect.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenOptions() {
		options.enabled = true;
		optionHeader.enabled = true;
		closeOptions.enabled = true;
		play.enabled = false;
		option.enabled = false;
		exit.enabled = false;
	}

	public void OpenLevelSelect() {

		play.enabled = false;
		option.enabled = false;
		exit.enabled = false;

		LevelSelect.enabled = true;
		levelSelectText.enabled = true;
		closeLevelSelect.enabled = true;
	}

	public void CloseSubmenu() {
		
		play.enabled = true;
		option.enabled = true;
		exit.enabled = true;

		options.enabled = false;
		optionHeader.enabled = false;
		closeOptions.enabled = false;

		LevelSelect.enabled = false;
		levelSelectText.enabled = false;
		closeLevelSelect.enabled = false;
	}
		
	public void Quit() {
		Application.Quit ();
	}
		
}
