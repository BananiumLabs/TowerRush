using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkRift;
using UnityEngine.SceneManagement;

public class Pl_NetworkManager : MonoBehaviour {

    //Object that will spawn when player connects
    public GameObject playerObject;

    //Our Player
    Transform player;

    void Start()
    {

        if (DarkRiftAPI.isConnected)
        {
            //Recieve Data
            DarkRiftAPI.onDataDetailed += ReceiveData;
            //Get everyone else to tell us to spawn them a player 
            DarkRiftAPI.SendMessageToOthers(TagIndex.Controller, TagIndex.ControllerSubjects.JoinMessage, "New Player Joined");
            //Spawn the player
            DarkRiftAPI.SendMessageToAll(TagIndex.Controller, TagIndex.ControllerSubjects.SpawnPlayer, Vars.lobby);
            //Instantiate(playerObject, Vars.lobby, Quaternion.identity);
        }
        else {
            Debug.LogWarning("Failed to connect to DarkRift Server!"); 
            SceneManager.LoadScene(0);
        }
    
    }

    void OnApplicationQuit()
    {
        DarkRiftAPI.Disconnect();

    }


    void ReceiveData(ushort senderID, byte tag, ushort subject, object data)
    {

        //Controller Tag
        if (tag == TagIndex.Controller && DarkRiftAPI.isConnected)
        {
            //If a player has joined tell them to give us a player
            if (subject == TagIndex.ControllerSubjects.JoinMessage)
            {
                //Tell them to spawn you
                DarkRiftAPI.SendMessageToID(senderID, TagIndex.Controller, TagIndex.ControllerSubjects.SpawnPlayer, player.position);
                //Later we should use another one to assign the username
            }

            //Spawn the player
            if (subject == TagIndex.ControllerSubjects.SpawnPlayer && DarkRiftAPI.isConnected)
            {
                //Instantiate the player
                GameObject clone = (GameObject)Instantiate(playerObject, (Vector3)data, Quaternion.identity);
                Debug.Log("Spawned Player");
                //Tell the network player who owns it so it tunes into the right updates.
                clone.GetComponent<N_Movement>().networkID = senderID;

                //If it's our player being created allow control and set the reference
                if (senderID == DarkRiftAPI.id && DarkRiftAPI.isConnected)
                {
                    clone.GetComponent<N_Movement>().isMine = true;
                    player = clone.transform;
                }
            }
        }
    }
}