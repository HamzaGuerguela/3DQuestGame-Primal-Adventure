using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class QteManager : MonoBehaviour
{
    #region Inspector

    private GameInput input;


    [SerializeField] private GameObject cutscene1;
    public bool eventWon;

    private bool myFunctionCalled = false;
    
    public int currentHealth;
    public int maxHealth;

    public BarScript barScript;

    public GameObject text;

    [Header("Cutscene Objects")]
    public GameObject bigStone;
    public GameObject stone;
    public GameObject fakePlayer;


    #endregion

    #region Unity Event Functions

    private void Awake()
    {
        input = new GameInput();
        input.Player.Minigame.performed += Minigame;
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void OnDestroy()
    {
        input.Player.Minigame.performed -= Minigame;
    }

    private void Update()
    {
        if (currentHealth >= maxHealth && !myFunctionCalled)
        {
            text.SetActive(false);
            Time.timeScale = 1.0f;
            myFunctionCalled = true;
            Invoke("EventWon", 0f);
        }
    }

    #endregion
    
    private void Minigame(InputAction.CallbackContext _)
    {
        TakeDamage(20);
    }

    void TakeDamage(int damage)
    {
        currentHealth += damage;
        
        barScript.SetHealth(currentHealth);
    }

    private void EventWon()
    {
        eventWon = true;
        Invoke("DelayedStoneDestroy", 7f);
        Debug.Log("WIN");
    }

    private void DelayedStoneDestroy()
    {
        Destroy(stone);
    }

    public void QteResult()
    {
        Time.timeScale = 1.0f;

        if (!eventWon)
        {
            QteLost();
            currentHealth = 0;
            barScript.SetHealth(currentHealth);
        }
        else
        {
            return;
        }
    }
    
    private void QteLost()
    {
        FindObjectOfType<GameController>().CutsceneFadeOut();
        Invoke("DelayedPlayerEnable",1f);
        FindObjectOfType<PlayableDirector>().Stop();
        Debug.Log("lost");
        
    }

    private void DelayedPlayerEnable()
    {
        FindObjectOfType<GameController>().ActivatePlayer();
        fakePlayer.SetActive(false);
        bigStone.SetActive(true);
        stone.SetActive(true);
    }
    
    
}
