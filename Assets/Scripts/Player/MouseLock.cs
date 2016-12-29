using UnityEngine;
using System.Collections;

///Locks the mouse onto the center of the screen during play.
public class MouseLock : MonoBehaviour
{

    // Apply requested cursor state
    void SetCursorState()
    {
		Cursor.lockState = Vars.lockMode;
        // Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != Vars.lockMode);
    }
    void OnGUI()
    {
        GUILayout.BeginVertical();
        // Release cursor on escape keypress
        if (Input.GetKeyDown(KeyCode.Escape))
			Cursor.lockState = Vars.lockMode = CursorLockMode.None;

        GUILayout.EndVertical();

        SetCursorState();
    }

    void Update()
    {
       //if (Input.GetMouseButtonDown(0))
		//	Vars.lockMode = CursorLockMode.Locked;
    }
} 