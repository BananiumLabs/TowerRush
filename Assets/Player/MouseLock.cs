using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour
{
    CursorLockMode isLocked;

    // Apply requested cursor state
    void SetCursorState()
    {
        Cursor.lockState = isLocked;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != isLocked);
    }

    void OnGUI()
    {
        GUILayout.BeginVertical();
        // Release cursor on escape keypress
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = isLocked = CursorLockMode.None;

        GUILayout.EndVertical();

        SetCursorState();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            isLocked = CursorLockMode.Locked;
    }
}