using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//SUMMARY: Code for in-game menus and displays. Attached to the Main Camera on player.
public class PlayerGUI : MonoBehaviour {

	private bool isPause = false;
	public SpriteRenderer crosshair;
	public CanvasGroup pauseMenu;
	public CanvasGroup teamSelect;

	void Start () {
		crosshair = crosshair.GetComponent<SpriteRenderer> ();
		pauseMenu = pauseMenu.GetComponent<CanvasGroup> ();
		teamSelect = teamSelect.GetComponent<CanvasGroup> ();

		crosshair.enabled = true;
		pauseMenu.alpha = 0f;
		//TeamSelect (false);
	}


	void Update () {


		//Escape Menu
		if(Input.GetKeyDown(KeyCode.Escape)) {
			isPause = !isPause;

			if (isPause) {
				Time.timeScale = 0;
				crosshair.enabled = false;
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				pauseMenu.alpha = 1f;
				Debug.Log ("Paused");

			} else if (!isPause /*&& teamSelect.alpha == 0f*/) {
				Time.timeScale = 1;
				crosshair.enabled = true;
				pauseMenu.alpha = 0f;
				TeamSelect (false);
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
				Debug.Log ("Back to Game");
			} else {
				pauseMenu.alpha = 0f;
				Debug.Log ("Team Select");
			}
		}
	}

	public void TeamSelect (bool OpenOrClosed) {
		if (OpenOrClosed) {
			teamSelect.alpha = 1f;
			isPause = false;
		} else {
			teamSelect.alpha = 0f;
		}

	}

	public void Quit () {
		//When "Quit to Main Menu" is pressed
		Cursor.visible = true;
		SceneManager.LoadScene (0);
	}
}
