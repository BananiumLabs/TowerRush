using UnityEngine;

///File containing all global variables. All variables accessible through Vars.[varname]
public class Vars : MonoBehaviour {

	public static Vector3 testMapBlue = new Vector3(0,4,-281);
	public static Vector3 testMapGold = new Vector3(0,3,134);
	public static CursorLockMode lockMode;
	public static Vector3 lobby = new Vector3(0,0,0);
	
	public enum Team {blue, gold};

	public static string path = Application.dataPath;
}
