using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 movement;

    private PlayerInput playerInput;
    public InputAction movementAction;
    //private void Awake()
    //{
    //    playerInput = GetComponent<PlayerInput>();
    //    movementAction = playerInput.actions["Movement"];
    //}

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        movementAction = playerInput.actions["movement"];
    }

    private void Update()
    {
        playerInput = GetComponent<PlayerInput>();
        movementAction = playerInput.actions["movement"];
        movement = movementAction.ReadValue<Vector2>();
    }
}
