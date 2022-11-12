using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Start()
    {
        EnterPlayMode();
    }


    private void EnterPlayMode()
    {
        // In the editor: Unlock with ESC.
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
