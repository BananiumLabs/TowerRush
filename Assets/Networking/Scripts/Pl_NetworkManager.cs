using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkRift;

public class Pl_NetworkManager : MonoBehaviour {

    //This is the server IP
    public string IP = "127.0.0.1";

    //Object that will spawn when player connects
    public GameObject playerObject;

    //Our Player
    Transform player;

    void Start()
    {
        
        DarkRiftAPI.Connect(IP);

        //Recieve Data
        DarkRiftAPI.onDataDetailed += ReceiveData;

        if (DarkRiftAPI.isConnected)
        {
            //Get everyone else to tell us to spawn them a player 
            DarkRiftAPI.SendMessageToOthers(TagIndex.Controller, TagIndex.ControllerSubjects.JoinMessage, "New Player Joined");
            //Spawn the player
            Debug.Log("Spawning");
            DarkRiftAPI.SendMessageToAll(TagIndex.Controller, TagIndex.ControllerSubjects.SpawnPlayer, new Vector3(0f, 0f, 0f));
        }
        else
            Debug.Log("Failed to connect to DarkRift Server!");

    }

    void OnApplicationQuit()
    {
        DarkRiftAPI.Disconnect();
    }


    void ReceiveData(ushort senderID, byte tag, ushort subject, object data)
    {
        //When any data is received it will be passed here, 
        //we then need to process it if it's got a tag of 0 and, if 
        //so, create an object. This is where you'd handle most admin 
        //stuff like that.

        //Ok, if data has a Controller tag then it's for us
        if (tag == TagIndex.Controller)
        {
            //If a player has joined tell them to give us a player
            if (subject == TagIndex.ControllerSubjects.JoinMessage)
            {
                //Tell them to spawn you
                DarkRiftAPI.SendMessageToID(senderID, TagIndex.Controller, TagIndex.ControllerSubjects.SpawnPlayer, player.position);
            }

            //Spawn the player
            if (subject == TagIndex.ControllerSubjects.SpawnPlayer)
            {
                //Instantiate the player
                GameObject clone = (GameObject)Instantiate(playerObject, (Vector3)data, Quaternion.identity);
                //Tell the network player who owns it so it tunes into the right updates.
                clone.GetComponent<NetworkPlayer>().networkID = senderID;

                //If it's our player being created allow control and set the reference
                if (senderID == DarkRiftAPI.id)
                {
                    clone.GetComponent<N_Movement>().isMine = true;
                    player = clone.transform;
                }
            }
        }
    }
}
