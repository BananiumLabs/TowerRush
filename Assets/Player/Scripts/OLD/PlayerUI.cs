using UnityEngine;
using System.Collections;

public class PlayerUI : MonoBehaviour {

    private bool isPause = false;
    public SpriteRenderer crosshair;
    public CanvasGroup teamCanvas;
    public CanvasGroup playerCanvas;
    public CanvasGroup pauseCanvas;


	// Use this for initialization
	void Start () {
        crosshair = crosshair.GetComponent<SpriteRenderer>();
        pauseCanvas = pauseCanvas.GetComponent<CanvasGroup>();
        teamCanvas = teamCanvas.GetComponent<CanvasGroup>();
        playerCanvas = playerCanvas.GetComponent<CanvasGroup>();

        crosshair.enabled = false;
        pauseCanvas.alpha = 0f;
        playerCanvas.alpha = 0f;
        teamCanvas.alpha = 0f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (teamCanvas.alpha == 0f)
            isPause = !isPause;


            if (isPause)
            {
                crosshair.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                pauseCanvas.alpha = 1f;
                Debug.Log("Paused");

            }
            else if ((!isPause && teamCanvas.alpha == 0f) || (teamCanvas.alpha == 1f))
            {
                crosshair.enabled = true;
                pauseCanvas.alpha = 0f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("Back to Game");
            }
            else if (!isPause && teamCanvas.alpha == 1f)
            {
                pauseCanvas.alpha = 0f;
                Debug.Log("Team Select");
            }

        }
  
	}
}
