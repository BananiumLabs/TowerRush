using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonActions : MonoBehaviour {
	private GameObject gui; 
	private PlayerGUI pgui;
	void Start () {
		gui = GameObject.Find("RoomGui");
		pgui = gui.GetComponent<PlayerGUI> ();
	}
	
	public void QuitToMainMenu () {
		SceneManager.LoadScene(0);
	}
	
	public void SwitchTeams () {
		pgui.SwitchTeams();
	}
	
	public void CloseTeamSelect () {
		pgui.CloseTeamSelect();
	}
}
