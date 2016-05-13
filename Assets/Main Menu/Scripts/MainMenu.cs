using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

//Code for the entire main menu (EXCEPT Options)
public class MainMenu : MonoBehaviour {
	public Button play;
	public Button option;
	public Button exit;
	public Button credits;

	public Canvas options;
	public Canvas levelSelect;
	public Canvas creditsMenu;

	public Dropdown optionDropdown;
	public Canvas general;
	public Canvas controls;

	private int levelNumber;

	void Start () {

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		credits = credits.GetComponent<Button> ();
		play = play.GetComponent<Button> ();
		option = option.GetComponent<Button> ();
		exit = exit.GetComponent<Button> ();

		levelSelect = levelSelect.GetComponent<Canvas> ();
		options = options.GetComponent<Canvas> ();
		creditsMenu = creditsMenu.GetComponent<Canvas> ();

		optionDropdown = optionDropdown.GetComponent<Dropdown> ();
		general = general.GetComponent<Canvas> ();
		controls = controls.GetComponent<Canvas> ();

		EnableMainButtons (true);

		options.enabled = false;
		levelSelect.enabled = false;
		creditsMenu.enabled = false;

	}

	void Update () {
		
	}

	//Unused, might be useful later
	private void EnableChildren(Component[] Parent, bool enabled) {
		Parent = GetComponentsInChildren<Image> ();
		foreach (Image child in Parent) {
			child.enabled = true;
		}
	}

	//Used for toggling submenus
	private void EnableMainButtons(bool trueOrFalse) {
		play.enabled = trueOrFalse;
		option.enabled = trueOrFalse;
		exit.enabled = trueOrFalse;
		credits.enabled = trueOrFalse;
	}
		
	public void OpenLevelSelect() {

		EnableMainButtons (false);
		levelSelect.enabled = true;
	}

	public void OpenOptions() {
		
		EnableMainButtons(false);
		options.enabled = true;
		optionDropdown.value = 0;
		general.transform.rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);

	}

	public void OpenCredits() {

		EnableMainButtons (false);
		creditsMenu.enabled = true;

	}

	//Code for closing every submenu
	public void CloseSubmenu() {
		
		EnableMainButtons (true);

		options.enabled = false;
		levelSelect.enabled = false;
		creditsMenu.enabled = false;

	}

	//When the level buttons are pressed
	public void SelectLevel(int level) {
		levelNumber = level;
	}

	//When the "Join" button is pressed
	public void LoadLevel() {
		if (levelNumber != null)
			SceneManager.LoadScene (levelNumber);
	}

	//Quits the entire game
	public void Quit() {
		Application.Quit ();
	}
		
}
