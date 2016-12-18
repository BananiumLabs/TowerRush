using UnityEngine;
using UnityEngine.SceneManagement;
using DarkRift;


public class ButtonActions : MonoBehaviour {
	public PlayerGUI pgui;
	protected Transform playerTransform;
	public Vars.Team team;

	void Start () {
		pgui = GetComponent<PlayerGUI> ();
		playerTransform = GetComponentInParent<Transform> ();
	}
	
	public void QuitToMainMenu () {
		DarkRiftAPI.Disconnect();
		SceneManager.LoadScene(0); //Load Main Menu
	}
	
	public void SwitchTeams () {
		pgui.SwitchTeams();
	}
	
	public void CloseTeamSelect () {
		pgui.CloseTeamSelect();
	}

	public void joinBlue()
    {
        if(!Input.GetKey(KeyCode.Space)) {
            Debug.Log("JOINING BLUE");
        	playerTransform.position = Vars.testMapBlue;
       		team = Vars.Team.blue;
        	CloseTeamSelect();
        	playerTransform.tag = "BluePlayer";
		}
    }

    public void joinGold()
    {
        if(!Input.GetKey(KeyCode.Space)) {
            Debug.Log("JOINING GOLD");
        	playerTransform.position = Vars.testMapGold;
       		team = Vars.Team.gold;
        	CloseTeamSelect();
        	playerTransform.tag = "GoldPlayer";
		}
        
    }
}
