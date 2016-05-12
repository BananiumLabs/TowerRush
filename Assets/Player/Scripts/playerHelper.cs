using UnityEngine;
using System.Collections;

public class playerHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public static bool GetCursorState
    {
        get
        {
            if (Cursor.visible && Cursor.lockState != CursorLockMode.Locked)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
