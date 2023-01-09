using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QteManager : MonoBehaviour
{
    #region Inspector

    private GameInput input;

    bool myFunctionCalled = false;
    
    public int currentHealth;
    public int maxHealth;

    public BarScript barScript;
    

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
        Debug.Log("WIN");
    }
}
