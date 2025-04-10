using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CollisionsTestStartRoom
{
    private GameObject player;
    private PlayerMovement controller;
    private InputAction moveAction;
    private InputManager inputManager;
    private Camera testCamera;

    [SetUp]
    public void Setup()
    {
        // Load scene asynchronously
        SceneManager.LoadScene("StartRoomScene", LoadSceneMode.Single);
        // Yield for the scene to load
        // Allow one frame for the scene to load
        //yield return null;

        // Camera setup
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

        // Ensure InputManager is attached to the player
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


    // A Test behaves as an ordinary method
    [Test]
    public void CollisionsTestStartRoomSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CollisionsTestStartRoomWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(10.1f);
        yield return null;
    }
}
