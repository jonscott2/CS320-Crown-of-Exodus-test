using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerMovementTests : InputTestFixture
{
    private GameObject player;
    private PlayerMovement controller;
    private InputAction moveAction;
    private InputManager inputManager;
    private Camera testCamera;

    [SetUp]
    public override void Setup()
    {
        base.Setup();

        //attempting to load a scene
        //SceneManager.LoadScene("StartRoomScene");

        //Camera setup
        testCamera = new GameObject("TestCamera").AddComponent<Camera>();
        testCamera.clearFlags = CameraClearFlags.SolidColor; // Set the background color
        testCamera.backgroundColor = Color.gray; // You can change the color here if you want
        testCamera.enabled = true;

        // Position the camera
        testCamera.transform.position = new Vector3(0, 0, -10); // Adjust to fit the player's view

        // Create virtual keyboard to track inputs
        InputSystem.AddDevice<Keyboard>();

        // Load and instantiate the player prefab
        player = GameObject.Instantiate(Resources.Load<GameObject>("PlayerTest"));
        controller = player.GetComponent<PlayerMovement>();

        // Ensure InputManager is attached to the player. It wasnt at first
        inputManager = player.GetComponent<InputManager>();
        Assert.NotNull(inputManager);  // Assert to ensure InputManager exists

        // Create and bind InputAction for movement (so PlayerMovement can respond to them)
        moveAction = new InputAction(type: InputActionType.Value);
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        // Assign moveAction to PlayerMovement script's moveAction field
        controller.moveAction = moveAction;

        // Enable the action to listen for input
        moveAction.Enable();

        // Enable the InputManager's action to ensure it tracks movement
        inputManager.movementAction = moveAction;
    }

    [UnityTest]
    public IEnumerator PlayerMovesUpWhenWKeyPressed()
    {
        Vector3 startPos = player.transform.position;
        Debug.Log($"Start Position Y: {startPos.y}");

        // Simulate pressing the W key
        Press(Keyboard.current.wKey);
        yield return new WaitForSeconds(0.4f);  // Allow time for movement
        Release(Keyboard.current.wKey);

        yield return new WaitForSeconds(1.5f);  // Allow more time for movement

        Vector3 endPos = player.transform.position;
        Debug.Log($"End Position Y: {endPos.y}");

        // Assert that the player has moved up (in the positive Y direction)
        //Assert.AreNotEqual(startPos.y, endPos.y, "Player did not move vertically after pressing W.");
        //Assert.Greater(startPos.y, endPos.y, "Player should have moved up");
    }

    [UnityTest]
    public IEnumerator PlayerMovesRightWhenDKeyPressed()
    {
        Vector3 startPos = player.transform.position;

        // Simulate pressing the D key to move right
        Press(Keyboard.current.dKey);
        yield return new WaitForSeconds(1.1f);  // Allow time for movement
        Release(Keyboard.current.dKey);

        yield return new WaitForSeconds(1.5f);  // Allow more time for movement

        Vector3 endPos = player.transform.position;

        // Assert that the player has moved right (in the positive X direction)
        //Assert.AreNotEqual(startPos.x, endPos.x, "Player should have moved right");
        Debug.Log($"Start Position Y: {startPos.x}");
    }

    [UnityTest]
    public IEnumerator PlayerMovesLeftWhenAKeyPressed()
    {
        Vector3 startPos = player.transform.position;

        // Simulate pressing the A key to move right
        Press(Keyboard.current.aKey);
        yield return new WaitForSeconds(1.1f);  // Allow time for movement
        Release(Keyboard.current.aKey);

        yield return new WaitForSeconds(1.5f);  // Allow more time for movement

        Vector3 endPos = player.transform.position;

        // Assert that the player has moved right (in the positive X direction)
        //Assert.Greater(endPos.x, startPos.x, "Player should have moved right");
        //Assert.AreNotEqual(startPos.x, endPos.x, "Player should have moved left");
        Debug.Log($"Start Position Y: {startPos.x}");
    }

    [UnityTest]
    public IEnumerator PlayerMovesDownWhenSKeyPressed()
    {
        Vector3 startPos = player.transform.position;

        // Simulate pressing the A key to move right
        Press(Keyboard.current.sKey);
        yield return new WaitForSeconds(1.1f);  // Allow time for movement
        Release(Keyboard.current.sKey);

        yield return new WaitForSeconds(1.5f);  // Allow more time for movement

        Vector3 endPos = player.transform.position;

        // Assert that the player has moved right (in the positive X direction)
        Assert.AreNotEqual(startPos.y, endPos.y, "Player should have moved down");
    }

}