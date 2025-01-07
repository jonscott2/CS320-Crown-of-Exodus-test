using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// This script acts as a single point for all other scripts to get
// the current input from. It uses Unity's new Input System and
// functions should be mapped to their corresponding controls
// using a PlayerInput component with Unity Events.

[RequireComponent(typeof(PlayerInput))]
public class InputManager1 : MonoBehaviour
{
    public bool interactPressed = false;
    private bool submitPressed = false;
    private PlayerInput playerInput;

    public GameObject cutsceneSlot;
    public Scene currentScene = SceneManager.GetActiveScene();

    private static InputManager1 instance;
    private InputAction interactAction;
    private InputAction submitAction;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }

        instance = this;

        playerInput = GetComponent<PlayerInput>();
        interactAction = playerInput.actions["InteractButtonPressed"];
        submitAction = playerInput.actions["SubmitButtonPressed"];

    }

    private void Start()
    {
        cutsceneSlot.SetActive(false);
    }

    private void Update()
    {
        if (interactAction.ReadValue<float>() == 1)
        {
            interactPressed = true;
            cutsceneSlot.SetActive(true);
        }
        else
        {
            interactPressed = false;
        }

        if (submitAction.ReadValue<float>() == 1)
        {
            submitPressed = true;
        }
        else
        {
            submitPressed = false;
        }
    }

    public static InputManager1 GetInstance()
    {
        return instance;
    }

    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }

    public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        }
    }

    // for any of the below 'Get' methods, if we're getting it then we're also using it,
    // which means we should set it to false so that it can't be used again until actually
    // pressed again.

    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    public bool GetSubmitPressed()
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }

    public void RegisterSubmitPressed()
    {
        submitPressed = false;
    }

}