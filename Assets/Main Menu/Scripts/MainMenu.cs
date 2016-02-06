using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Button play;
	public Button option;
	public Button exit;
	public Button credits;

	public Button closeOptions;
	public Text optionHeader;
	public Canvas options;

	public Button closeLevelSelect;
	public Text levelSelectText;
	public Canvas LevelSelect;
	public SpriteRenderer LevelSelectLeft;
	public SpriteRenderer LevelSelectRight;
	public Image LevelOne;

	// Use this for initialization
	void Start () {
		closeOptions = closeOptions.GetComponent<Button> ();
		optionHeader = optionHeader.GetComponent<Text> ();
		options = options.GetComponent<Canvas> ();

		credits = credits.GetComponent<Button> ();
		play = play.GetComponent<Button> ();
		option = option.GetComponent<Button> ();
		exit = exit.GetComponent<Button> ();

		closeLevelSelect = closeLevelSelect.GetComponent<Button> ();
		levelSelectText = levelSelectText.GetComponent<Text> ();
		LevelSelect = LevelSelect.GetComponent<Canvas> ();
		LevelSelectLeft = LevelSelectLeft.GetComponent<SpriteRenderer> ();
		LevelSelectRight = LevelSelectRight.GetComponent<SpriteRenderer> ();
		LevelOne = LevelOne.GetComponent<Image> ();

		play.enabled = true;
		option.enabled = true;
		exit.enabled = true;
		credits.enabled = true;

		options.enabled = false;
		optionHeader.enabled = false;
		closeOptions.enabled = false;

		LevelSelect.enabled = false;
		levelSelectText.enabled = false;
		closeLevelSelect.enabled = false;
		LevelSelectLeft.enabled = false;
		LevelSelectRight.enabled = false;
		LevelOne.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DisableMainButtons() {
		play.enabled = false;
		option.enabled = false;
		exit.enabled = false;
		credits.enabled = false;
	}
		

	public void OpenOptions() {
		options.enabled = true;
		optionHeader.enabled = true;
		closeOptions.enabled = true;
		DisableMainButtons ();
		
	}

	public void OpenLevelSelect() {

		DisableMainButtons ();

		LevelSelect.enabled = true;
		levelSelectText.enabled = true;
		closeLevelSelect.enabled = true;
		LevelSelectLeft.enabled = true;
		LevelSelectRight.enabled = true;
		LevelOne.enabled = true;
	}

	public void CloseSubmenu() {
		
		play.enabled = true;
		option.enabled = true;
		exit.enabled = true;
		credits.enabled = true;

		options.enabled = false;
		optionHeader.enabled = false;
		closeOptions.enabled = false;

		LevelSelect.enabled = false;
		levelSelectText.enabled = false;
		closeLevelSelect.enabled = false;
		LevelSelectLeft.enabled = false;
		LevelSelectRight.enabled = false;
		LevelOne.enabled = false;

	}
		
	public void Quit() {
		Application.Quit ();
	}
		
}
