using UnityEngine;

public class PlayerGUI : MonoBehaviour {

	public Canvas HUD, PauseMenu, TeamSelection, Options;
	public Pl_MouseLook mLookX, mLookY;

	///0 = HUD, 1 = TeamSelection, 2 = PauseMenu, 3 = Options
	protected bool[] enabledCanvases; 
	
	void Start () {
		enabledCanvases = new bool[] {false, true, false, false};
	}
	
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Escape();
		}

		ManageCanvases();

	}

	///When Switch Teams button is pressed
	public void SwitchTeams () {
		enabledCanvases[0] = false;
		enabledCanvases[1] = true;
		enabledCanvases[2] = false;
	}
	
	public void CloseTeamSelect () {
		enabledCanvases[0] = true;
		enabledCanvases[1] = false;
	}

	///Translates enabledCanvases[] into actions
	public void ManageCanvases () {
		HUD.enabled = (enabledCanvases[0]) ? true : false;
		TeamSelection.enabled = (enabledCanvases[1]) ? true : false;
		PauseMenu.enabled = (enabledCanvases[2]) ? true : false;
		Options.enabled = (enabledCanvases[3]) ? true : false;

		//Enables and disables MouseLook based on open canvases
		if(enabledCanvases[0] && !enabledCanvases[2] && !enabledCanvases[3]) {
			mLookX.enabled = true;
			mLookY.enabled = true;
		} else {
			mLookX.enabled = false;
			mLookY.enabled = false;
		}
	}

	///Escape key action
	public void Escape () {
		for(int i = enabledCanvases.Length - 1; i >= 0; i--) {
			if(enabledCanvases[i] && i != 0) {
				enabledCanvases[i] = false;
				break;
			} else if (i == 0)
				enabledCanvases[2] = true;
		}
	}

	public void OpenOptions () {
		enabledCanvases[3] = true;
		enabledCanvases[2] = false;
	}

	public void CloseOptions () {
		enabledCanvases[3] = false;
	}
}
