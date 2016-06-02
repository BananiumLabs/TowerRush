using UnityEngine;
using System.Collections;
using UnityEngine.UI;

///<summary> Manages team functions for players </summary>
public class TeamManager : MonoBehaviour {

	
	private Button gold;
	private Button blue;
	private Transform playerTransform;
	private ButtonActions buttons;
	public Vars.Team team;
	void Start () {
		gold = GameObject.Find("Gold").GetComponent<Button> ();
		blue = GameObject.Find("Blue").GetComponent<Button> ();
		playerTransform = GetComponentInParent<Transform> ();
		buttons = GameObject.Find("RoomGui").GetComponent<ButtonActions> ();
	}
	
	void Update () {
		blue.onClick.AddListener(() => joinBlue() );
		gold.onClick.AddListener(() => joinGold() );
	}
	
	public void joinBlue () {
		playerTransform.position = Vars.testMapBlue;
		team = Vars.Team.blue;
		buttons.CloseTeamSelect();
	}
	
	public void joinGold () {
		playerTransform.position = Vars.testMapGold;
		team = Vars.Team.gold;
		buttons.CloseTeamSelect();
	}
}
