using UnityEngine;

///File containing all global variables. All variables accessible through Vars.[varname]
public class Vars : MonoBehaviour {

	//Coordinates for TestMap (index 1)
	public static Vector3 testMapBlue = new Vector3(0,4,-281);
	public static Vector3 testMapGold = new Vector3(0,3,134);

	///Coordinates for lobby
	public static Vector3 lobby = new Vector3(0,0,0);
	
	///Possible teams a player can join
	public enum Team {blue, gold};

	///Path to config files
	public static string path = Application.dataPath;
}
