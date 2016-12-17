using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkRift;

public class Pl_NetworkManager : MonoBehaviour {

    public string IP = "127.0.0.1";

    void Start()
    {
        DarkRiftAPI.Connect(IP);
    }

    void OnApplicationQuit()
    {
        DarkRiftAPI.Disconnect();
    }
}
