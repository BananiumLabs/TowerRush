using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//SUMMARY: Code for in-game menus and displays. Attached to the Main Camera on player.
public class PlayerGUI : MonoBehaviour {

	private bool isPause = false;
	public SpriteRenderer crosshair;
	public CanvasGroup pauseMenu;

	void Start () {
		crosshair = crosshair.GetComponent<SpriteRenderer> ();
		pauseMenu = pauseMenu.GetComponent<CanvasGroup> ();

		crosshair.enabled = true;
		pauseMenu.alpha = 0f;
	}


	void Update () {
		//Escape Menu
		if(Input.GetKeyDown(KeyCode.Escape)) {
			isPause = !isPause;
			if (isPause) {
				Time.timeScale = 0;
				crosshair.enabled = false;
				pauseMenu.alpha = 1f;
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;

			} else {
				Time.timeScale = 1;
				crosshair.enabled = true;
				pauseMenu.alpha = 0f;
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
		}
	}

	public void Quit () {
		//When "Quit to Main Menu" is pressed
		Cursor.visible = true;
		SceneManager.LoadScene (0);
	}
}
