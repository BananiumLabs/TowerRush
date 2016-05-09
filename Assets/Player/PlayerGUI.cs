using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerGUI : MonoBehaviour {

	private bool isPause = false;
	public SpriteRenderer crosshair;
	public CanvasGroup pauseMenu;

	// Use this for initialization
	void Start () {
		crosshair = crosshair.GetComponent<SpriteRenderer> ();
		pauseMenu = pauseMenu.GetComponent<CanvasGroup> ();

		crosshair.enabled = true;
		pauseMenu.alpha = 0f;
	}
	
	// Update is called once per frame
	void Update () {
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
		SceneManager.LoadScene (0);
	}
}
