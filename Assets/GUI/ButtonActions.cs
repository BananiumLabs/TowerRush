using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonActions : MonoBehaviour {
	public GameObject gui; 
	public PlayerGUI pgui;
	void Start () {
		//gui = GameObject.Find("RoomGui");
		pgui = gui.GetComponent<PlayerGUI> ();
	}
	
	public void QuitToMainMenu () {
		PhotonNetwork.LeaveRoom();
	}
	
	public void SwitchTeams () {
		pgui.SwitchTeams();
	}
	
	public void CloseTeamSelect () {
		pgui.CloseTeamSelect();
	}
}
