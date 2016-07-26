using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

//Code for the entire main menu (EXCEPT Options)
public class MainMenu : MonoBehaviour {
	
	public Canvas homeScreen;
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

		levelSelect = levelSelect.GetComponent<Canvas> ();
		options = options.GetComponent<Canvas> ();
		creditsMenu = creditsMenu.GetComponent<Canvas> ();

		optionDropdown = optionDropdown.GetComponent<Dropdown> ();
		general = general.GetComponent<Canvas> ();
		controls = controls.GetComponent<Canvas> ();
		Debug.Log(SceneManager.GetActiveScene().buildIndex);

		CloseSubmenu();

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
		
	public void OpenLevelSelect() {

		homeScreen.enabled = false;
		levelSelect.enabled = true;
	}

	public void OpenOptions() {
		
		homeScreen.enabled = false;
		options.enabled = true;
		optionDropdown.value = 0;
		general.transform.rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
		general.enabled = true;

	}

	public void OpenCredits() {

		homeScreen.enabled = false;
		creditsMenu.enabled = true;

	}

	//Code for closing every submenu
	public void CloseSubmenu() {
		
		homeScreen.enabled = true;

		options.enabled = false;
			general.enabled = false;
		levelSelect.enabled = false;
		creditsMenu.enabled = false;

	}

	//When the level buttons are pressed
	public void SelectLevel(int level) {
			levelNumber = level;
	}

	//When the "Join" button is pressed
	public void LoadLevel() {
        Debug.Log("Initializing Level " + levelNumber);
        if (levelNumber != 0)
			SceneManager.LoadScene (levelNumber);
        //If No Level Was Selected(0), it defaults to 1.
        else
            SceneManager.LoadScene(1);
	}

	//Quits the entire game
	public void Quit() {
		Application.Quit ();
	}
		
}
