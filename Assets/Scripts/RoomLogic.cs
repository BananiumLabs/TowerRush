using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomLogic : MonoBehaviour {

    public Transform playerPrefab;

    public GameObject[] gspawn, bspawn;
	protected string playerTeam;
    public ButtonActions buttons;


    public GameObject[] blueCrates, goldCrates, crates;
    public Transform[] blueCrateSpawns, goldCrateSpawns;

    protected bool started;

    public void Awake()
    {
        // LoadMenu
       /*  if (!PhotonNetwork.connected)
        {
            SceneManager.LoadScene("MainMenu");
            return;
        }
        PhotonNetwork.isMessageQueueRunning = true;
        */

        foreach(var crate in crates) crate.SetActive(true);
    
    }

    public void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        
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
		Vars.lockMode = CursorLockMode.Locked;
        if(Application.isEditor || (GameObject.FindGameObjectsWithTag("Player").Length % 2 == 0 && !started)) {
            
            foreach(GameObject crate in crates) crate.SetActive(true);

            GameObject[] carryCrates = GameObject.FindGameObjectsWithTag("CarryCrate");
            GameObject[] supportCrates = GameObject.FindGameObjectsWithTag("SupportCrate");
            GameObject[] tankCrates = GameObject.FindGameObjectsWithTag("TankCrate");
            Debug.Log(carryCrates.Length);

            for(int i=0; i< /*(GameObject.FindGameObjectsWithTag("Player").Length/2) -1*/ 3; i++) {
            blueCrates.SetValue(
                (i % 3 == 0) 
                    ? Instantiate(carryCrates[Random.Range(0,carryCrates.Length-1)] , blueCrateSpawns[i].position, Quaternion.Euler(-90f,0,0))
                    : (i % 3 == 1) ? Instantiate(supportCrates[Random.Range(0,carryCrates.Length-1)], blueCrateSpawns[i].position, Quaternion.Euler(-90f,0,0))
                    : Instantiate (tankCrates[Random.Range(0,carryCrates.Length-1)], blueCrateSpawns[i].position, Quaternion.Euler(-90f,0,0) ) 
                , i); 
            goldCrates[i] = Instantiate(blueCrates[i], goldCrateSpawns[i].position, Quaternion.Euler(-90f,0,0));
            Debug.Log("Spawned crate " + i);
        }

        foreach(GameObject crate in crates) crate.SetActive(false);
        started = true;
        }
        else Debug.LogWarning("Teams are not even or game has already started! Enable debug mode to force start.");
    }

}
