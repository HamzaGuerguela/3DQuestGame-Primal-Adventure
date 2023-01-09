using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private PlayerController player;
    private DialogueController dialogueController;

    [SerializeField] private GameObject menu;

    [SerializeField] private GameObject playerObject;

    [SerializeField] private Animator fadeAnimator;

    [SerializeField] private GameObject bigStone;
    
    private GameInput Input;


    #region UnityEventFunctions

    private void Awake()
    {
        Input = new GameInput();
        Input.UI.Escape.performed += EscapePressed;
        
        
        player = FindObjectOfType<PlayerController>();
        if (player == null)
        {
            Debug.LogError("No player found in the scene !", this);
        }

        dialogueController = FindObjectOfType<DialogueController>();
        if (dialogueController == null)
        {
            Debug.LogError("No dialogueController found in the scene", this);
        }
    }

    private void OnEnable()
    {
        DialogueController.DialogueClosed += EndDialogue;
        Input.Enable();
    }

    private void Start()
    {
        EnterPlayMode();
    }

    private void OnDisable()
    {
        Input.Disable();
        DialogueController.DialogueClosed -= EndDialogue;
        Input.UI.Escape.performed -= EscapePressed;
    }

    private void EnterPauseMode()
    {
        // In the editor: Unlock with ESC.
        Cursor.lockState = CursorLockMode.None;
        player.DisableInput();
    }
    public void EnterPlayMode()
    {
        // In the editor: Unlock with ESC.
        Cursor.lockState = CursorLockMode.Locked;
        player.EnableInput();
    }


    public void EnterDialogueMode()
    {
        Cursor.lockState = CursorLockMode.None;
        player.DisableInput();
    }

    public void EnterCutsceneMode()
    {
        fadeAnimator.Play("ANIM_Fade_In");
        Cursor.lockState = CursorLockMode.Locked;
        player.DisableInput();
    }

    public void CutsceneFadeOut()
    {
        fadeAnimator.Play("ANIM_Fade_Out");
        
    }

    public void ActivatePlayer()
    {
        playerObject.SetActive(true);
        Destroy(bigStone);
    }
    
    public void DeactivatePlayer()
    {
        playerObject.SetActive(false);
    }
    
    #endregion


    public void StartDialogue(string dialoguePath)
    {
        EnterDialogueMode();
        dialogueController.StartDialogue(dialoguePath);
    }

    private void EndDialogue()
    {
        EnterPlayMode();
    }

    private void EscapePressed(InputAction.CallbackContext _)
    {
        if (menu == null)
        {
            return;
        }
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
            EnterPlayMode();
        }
        else if (!menu.activeInHierarchy)
        {
            menu.SetActive(true);
            EnterPauseMode();
        }
    }

    public void Continue()
    {
        menu.SetActive(false);
        EnterPlayMode();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
