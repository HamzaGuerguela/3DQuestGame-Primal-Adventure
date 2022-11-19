using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    
    [Tooltip("Invoked when the player interacts with the Interactable.")]
    [SerializeField] private UnityEvent onInteracted;
    
    [Tooltip("Invoked when the player selects this Interactable, and they are able to interact with it.")]
    [SerializeField] private UnityEvent onSelected;
    
    [Tooltip("Invoked when the player deselects this Interactable, and they stop being able to interact with it.")]
    [SerializeField] private UnityEvent onDeselected;


    public void Interact()
    {
        Debug.Log("Interact");
        onInteracted.Invoke();
    }

    public void Select()
    {
        Debug.Log("Select");
        onSelected.Invoke();
    }

    public void Deselect()
    {
        Debug.Log("Deselect");
        onDeselected.Invoke();
    }
}
