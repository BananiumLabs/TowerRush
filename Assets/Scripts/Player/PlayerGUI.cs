using UnityEngine;

public class PlayerGUI : MonoBehaviour {

	public Canvas HUD, PauseMenu, TeamSelection, Options, Inventory;
	public Pl_MouseLook mLookX, mLookY;
	protected InputManager input;

	///0 = HUD, 1 = TeamSelection, 2 = Inventory, 3 = PauseMenu, 4 = Options
	protected bool[] enabledCanvases; 
	
	void Start () {
		enabledCanvases = new bool[] {false, true, false, false, false};
		input = GetComponentInParent<InputManager> ();
	}
	
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Escape))
			Escape();

		if(input.GetKeyDown("Inventory")) {
			if(Active()) enabledCanvases[2] = true;
			else enabledCanvases[2] = false;	
		}

		ManageCanvases();

	}

	///Mouse lock function
	void OnGUI()
    {
        GUILayout.BeginVertical();

        //Lockss cursor when all menus but HUD are closed
        if (Active()) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        GUILayout.EndVertical();
		}
    }

	///When Switch Teams button is pressed
	public void SwitchTeams () {
		SetCanvases(false,true,false,false,false);
	}
	
	public void CloseTeamSelect () {
		SetCanvases(true,false,false,false,false);
	}

	///Changes the state of canvases
	protected void SetCanvases (bool tHUD, bool TSelection, bool Inv, bool Pause, bool tOptions) {
		enabledCanvases[0] = (tHUD) ? true : false;
		enabledCanvases[1] = (TSelection) ? true : false;
		enabledCanvases[2] = (Inv) ? true : false;
		enabledCanvases[3] = (Pause) ? true : false;
		enabledCanvases[4] = (tOptions) ? true : false;
	}

	///Translates enabledCanvases[] into actions
	public void ManageCanvases () {
		HUD.enabled = (enabledCanvases[0]) ? true : false;
		TeamSelection.enabled = (enabledCanvases[1]) ? true : false;
		Inventory.enabled = (enabledCanvases[2]) ? true : false;
		PauseMenu.enabled = (enabledCanvases[3]) ? true : false;
		Options.enabled = (enabledCanvases[4]) ? true : false;

		//Enables and disables MouseLook based on open canvases
		if(Active()) {
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
				enabledCanvases[3] = true;
		}
	}

	public void OpenOptions () {
		SetCanvases(true, false, false, false, true);
	}

	public void CloseOptions () {
		enabledCanvases[4] = false;
	}

	public bool Active () {
		return enabledCanvases[0] 
			&& !enabledCanvases[3] 
			&& !enabledCanvases[4]
			&& !enabledCanvases[2]
			&& !enabledCanvases[1];
	}
}
