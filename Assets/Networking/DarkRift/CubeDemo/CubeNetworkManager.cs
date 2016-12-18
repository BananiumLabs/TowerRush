using UnityEngine;
using System.Collections;

//First get access to the DarkRift namespace
using DarkRift;

public class CubeNetworkManager : MonoBehaviour
{
	public string IP = "localhost";

	void Start()
	{
		Debug.Log(DarkRiftAPI.Connect(IP));
	}

	void OnApplicationQuit()
	{
		DarkRiftAPI.Disconnect();
	}
}
