using UnityEngine;

public class PlayerGUI : MonoBehaviour {

	public Canvas HUD;
	public Canvas PauseMenu;
	public Canvas TeamSelection;
	
	void Start () {
		HUD = HUD.GetComponent<Canvas> ();
		PauseMenu = PauseMenu.GetComponent<Canvas> ();
		TeamSelection = TeamSelection.GetComponent<Canvas> ();
		
		TeamSelection.enabled = true;
		PauseMenu.enabled = false;
		HUD.enabled = false;
	}
	
	void Update () {
		//When ESC is pressed
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(!TeamSelection.enabled && !PauseMenu.enabled) {
				HUD.enabled = false;
				PauseMenu.enabled = true;
				Time.timeScale = 0;
			} else if(TeamSelection.enabled && !PauseMenu.enabled) {
				PauseMenu.enabled = true;
				Time.timeScale = 0;
			} else if(TeamSelection.enabled && PauseMenu.enabled) {
				PauseMenu.enabled = false;
				Time.timeScale = 0;
			} else if(!TeamSelection.enabled && PauseMenu.enabled) {
				PauseMenu.enabled = false;
				HUD.enabled = true;
				Time.timeScale = 1;
			} else Debug.LogError("Illegal GUI State");
		}
	}
	///When Switch Teams button is pressed
	public void SwitchTeams () {
		HUD.enabled = false;
		PauseMenu.enabled = false;
		TeamSelection.enabled = true;
	}
	
	public void CloseTeamSelect () {
		HUD.enabled = true;
		TeamSelection.enabled = false;
		Time.timeScale = 1;
	}
}
