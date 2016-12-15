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
		PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.player);
		PhotonNetwork.LeaveRoom();
		SceneManager.LoadScene(0); //Load Main Menu
	}
	
	public void SwitchTeams () {
		pgui.SwitchTeams();
	}
	
	public void CloseTeamSelect () {
		pgui.CloseTeamSelect();
	}
}
