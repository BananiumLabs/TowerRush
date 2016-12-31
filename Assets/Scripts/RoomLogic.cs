using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class RoomLogic : MonoBehaviour {


    public GameObject[] gspawn, bspawn;
	protected string playerTeam;


    public GameObject[] blueCrates, goldCrates, crates;
    public Transform[] blueCrateSpawns, goldCrateSpawns;

    protected bool started;

    public void Awake()
    {
        foreach(var crate in crates) crate.SetActive(true);
    
    }

    public void Start()
    {

    }

    void Update () {
        
    }

    //Returns player to base after a fall
    public void Respawn(Transform player) {
        if(player.tag == "BluePlayer") {
            player.position = bspawn[Random.Range(0,4)].transform.position;
        }
        else if(player.tag == "GoldPlayer") {
            player.position = gspawn[Random.Range(0,4)].transform.position;
        }
    }

    //Spawns crates upon game begin
    public void StartGame() {
        if(Application.isEditor || (GameObject.FindGameObjectsWithTag("Player").Length % 2 == 0 && !started)) {
            
            foreach(GameObject crate in crates) crate.SetActive(true);

            GameObject[] carryCrates = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g=>g.tag=="CarryCrate").ToArray();
            GameObject[] supportCrates = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g=>g.tag=="SupportCrate").ToArray();
            GameObject[] tankCrates = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g=>g.tag=="TankCrate").ToArray();
            Debug.Log(carryCrates.Length);

            //Below param commented out for debug purposes, so all types of crates will spawn
            for(int i=0; i < /*(GameObject.FindGameObjectsWithTag("Player").Length/2) -1*/ 3; i++) {
            //Instantiates a unique crate in each position
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
