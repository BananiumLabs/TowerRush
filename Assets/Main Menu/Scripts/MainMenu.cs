﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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

    // Use this for initialization
    void Start () {

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
	
	// Update is called once per frame
	void Update () {
	
	}

    private void EnableChildren(Component[] Parent, bool enabled) {
		Parent = GetComponentsInChildren<Image> ();
		foreach (Image child in Parent) {
			child.enabled = true;
		}
	}

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

	public void CloseSubmenu() {
		
		EnableMainButtons (true);

		options.enabled = false;
		levelSelect.enabled = false;
		creditsMenu.enabled = false;

	}

	public void SelectLevel(int level) {
		levelNumber = level;
	}

	public void LoadLevel() {
		if (levelNumber != null)
			SceneManager.LoadScene (levelNumber);
	}
		
	public void Quit() {
		Application.Quit ();
	}
		
}
