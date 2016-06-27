using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomLogic : MonoBehaviour {

    public Transform playerPrefab;

    public GameObject[] gspawn;
    public GameObject[] bspawn;
	private string playerTeam;
    public ButtonActions buttons;
    public Vars.Team team;

    public GameObject[] blueCrates;
    public Transform[] blueCrateSpawns;
    public GameObject[] goldCrates;
    public Transform[] goldCrateSpawns;
    public GameObject[] crates;
    private bool started;
    public bool debugMode;

    public void Awake()
    {
        // LoadMenu
        if (!PhotonNetwork.connected)
        {
            SceneManager.LoadScene("MainMenu");
            return;
        }
        PhotonNetwork.isMessageQueueRunning = true;

        foreach(var crate in crates) crate.SetActive(true);
    
    }

    public void Start()
    {
        PhotonNetwork.isMessageQueueRunning = true;


    }

    // Update is called once per frame
    void Update () {
        
    }

    public void joinBlue()
    {
        if(!Input.GetKey(KeyCode.Space)) {
            Debug.Log("JOINING BLUE");
        PhotonView photonView = PhotonView.Get(this);
        //playerTransform.position = Vars.testMapBlue;
        team = Vars.Team.blue;
        buttons.CloseTeamSelect();
        GameObject player = PhotonNetwork.Instantiate(this.playerPrefab.name, bspawn[Random.Range(0, 4)].transform.position, Quaternion.identity, 0);
        player.tag = "BluePlayer";
        //photonView.RPC("SpawnPlayerB", PhotonTargets.AllBuffered);
        }
        

    }

    public void joinGold()
    {
        if(!Input.GetKey(KeyCode.Space)) {
        Debug.Log("JOINING GOLD");
        PhotonView photonView = PhotonView.Get(this);
        //playerTransform.position = Vars.testMapGold;
        team = Vars.Team.gold;
        buttons.CloseTeamSelect();
        Debug.Log("test");
        GameObject player = PhotonNetwork.Instantiate(this.playerPrefab.name, gspawn[Random.Range(0,4)].transform.position, Quaternion.identity, 0);
        player.tag = "GoldPlayer";
        //photonView.RPC("SpawnPlayerG", PhotonTargets.AllBuffered);
        }
        
    }

    public void Respawn(Transform player) {
        if(player.tag == "BluePlayer") {
            player.position = bspawn[Random.Range(0,4)].transform.position;
        }
        else if(player.tag == "GoldPlayer") {
            player.position = gspawn[Random.Range(0,4)].transform.position;
        }
    }

    public void StartGame() {
        if(debugMode || (GameObject.FindGameObjectsWithTag("Player").Length % 2 == 0 && !started)) {
            foreach(GameObject crate in crates) crate.SetActive(true);

            GameObject[] carryCrates = GameObject.FindGameObjectsWithTag("CarryCrate");
            GameObject[] supportCrates = GameObject.FindGameObjectsWithTag("SupportCrate");
            GameObject[] tankCrates = GameObject.FindGameObjectsWithTag("TankCrate");
            Debug.Log(carryCrates.Length);

            for(int i=0; i< /*(GameObject.FindGameObjectsWithTag("Player").Length/2) -1*/ 3; i++) {
           
            blueCrates.SetValue(
                (i % 3 == 0) 
                    ? PhotonNetwork.Instantiate(carryCrates[Random.Range(0,carryCrates.Length-1)].name , blueCrateSpawns[i].position, Quaternion.identity, 0)
                    : (i % 3 == 1) ? PhotonNetwork.Instantiate(supportCrates[Random.Range(0,carryCrates.Length-1)].name, blueCrateSpawns[i].position, Quaternion.identity, 0 )
                    : PhotonNetwork.Instantiate (tankCrates[Random.Range(0,carryCrates.Length-1)].name, blueCrateSpawns[i].position, Quaternion.identity, 0 ) 
                , i); 
            goldCrates[i] = GameObject.Instantiate(blueCrates[i]);
            goldCrates[i].transform.position = goldCrateSpawns[i].position;
            Debug.Log("Spawned crate " + i);
        }

        foreach(GameObject crate in crates) crate.SetActive(false);
        started = true;
        }
        else Debug.LogWarning("Teams are not even! Cannot start match");
    }

}
