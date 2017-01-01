using UnityEngine;
using UnityEngine.SceneManagement;
using DarkRift;


public class ButtonActions : MonoBehaviour {
	public PlayerGUI pgui;
	public Transform playerTransform;
	public Vars.Team team;

	void Start () {
		pgui = GetComponent<PlayerGUI> ();
	}
	
	public void QuitToMainMenu () {
		Destroy(playerTransform.gameObject);
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
            Debug.Log("JOINING BLUE");
        	playerTransform.position = Vars.testMapBlue;
       		team = Vars.Team.blue;
        	CloseTeamSelect();
        	playerTransform.tag = "BluePlayer";
    }

    public void joinGold()
    {
       
            Debug.Log("JOINING GOLD");
        	playerTransform.position = Vars.testMapGold;
       		team = Vars.Team.gold;
        	CloseTeamSelect();
        	playerTransform.tag = "GoldPlayer";
        
    }

	public void StartGame()
	{
		GetComponentInParent<Pl_Controller>().roomlogic.StartGame();
	}
}
