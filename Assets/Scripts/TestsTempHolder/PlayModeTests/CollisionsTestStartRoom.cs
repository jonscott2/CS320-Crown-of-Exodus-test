using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.LowLevel;
using System.Collections.Generic;

public class CollsionTest : InputTestFixture
{
    private GameObject player;
    private PlayerController controller;
    private InputAction moveAction;
    private Keyboard testKeyboard;


    [SetUp]
    public override void Setup()
    {
        base.Setup(); // Set up the InputTestFixture (keyboard device support etc.)
    }

    [UnitySetUp]
    public IEnumerator UnitySetUp()
    {
        base.Setup();

        // Load the scene
        var loadOp = SceneManager.LoadSceneAsync("StartRoomScene", LoadSceneMode.Single);
        while (!loadOp.isDone)
            yield return null;

        yield return null; // Let everything initialize

        // Create and register a virtual keyboard
        if (testKeyboard == null)
        {
            testKeyboard = InputSystem.AddDevice<Keyboard>();
        }
        InputSystem.QueueStateEvent(testKeyboard, new KeyboardState());
        InputSystem.Update();

        // Find the Player
        player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player, "Couldn't find Player in scene. Make sure it is tagged 'Player'.");

        controller = player.GetComponent<PlayerController>();
        Assert.IsNotNull(controller, "PlayerController script not found.");

        // Create and assign test InputAction
        moveAction = new InputAction(type: InputActionType.Value);
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        moveAction.Enable();

        // Inject this test action into the controller
        controller.playerControlls = moveAction;
    }

    [TearDown]
    public void SimpleTearDown()
    {
        if (testKeyboard != null)
        {
            InputSystem.RemoveDevice(testKeyboard);
            testKeyboard = null;
        }

        if (moveAction != null)
        {
            moveAction.Disable();
            moveAction.Dispose();
            moveAction = null;
        }

        player = null;
        controller = null;
    }

    [UnityTest]
    public IEnumerator PlayerMovesUpWhenWIsPressed()
    {
        yield return new WaitForSeconds(0.5f); // Wait for scene setup

        // Add virtual keyboard
        var keyboard = InputSystem.AddDevice<Keyboard>();

        // Re-assign controls to use this keyboard
        controller.playerControlls = new InputAction(type: InputActionType.Value);
        controller.playerControlls.AddCompositeBinding("2DVector")
            .With("Up", keyboard.wKey.path)
            .With("Down", keyboard.sKey.path)
            .With("Left", keyboard.aKey.path)
            .With("Right", keyboard.dKey.path);
        controller.playerControlls.Enable();

        // Manually hook up the OnMove callback if needed
        controller.playerControlls.performed += controller.OnMove;
        controller.playerControlls.canceled += controller.OnMove;

        yield return new WaitForSeconds(0.1f); // Wait for enable

        Vector3 startPos = controller.transform.position;

        // first move up
        Press(keyboard.wKey);
        yield return new WaitForSeconds(1.5f); // Let movement happen
        Release(keyboard.wKey);

        yield return new WaitForSeconds(.5f); // Let it settle

        // move left
        Press(keyboard.aKey);
        yield return new WaitForSeconds(1.5f); // Let movement happen
        Release(keyboard.aKey);

        yield return new WaitForSeconds(.5f); // Let it settle

        // move down
        Press(keyboard.sKey);
        yield return new WaitForSeconds(0.5f); // Let movement happen
        Release(keyboard.sKey);

        // move left
        Press(keyboard.aKey);
        yield return new WaitForSeconds(2.0f); // Let movement happen
        Release(keyboard.aKey);

        // move right
        Press(keyboard.dKey);
        yield return new WaitForSeconds(0.5f); // Let movement happen
        Release(keyboard.dKey);

        // move down
        Press(keyboard.sKey);
        yield return new WaitForSeconds(0.5f); // Let movement happen
        Release(keyboard.sKey);

        yield return new WaitForSeconds(1.0f);

        // move right
        Press(keyboard.dKey);
        yield return new WaitForSeconds(0.5f); // Let movement happen
        Release(keyboard.dKey);

        yield return new WaitForSeconds(1.0f);

        Vector3 endPos = controller.transform.position;
        Debug.Log($"Moved from {startPos} to {endPos}");

        Assert.AreNotEqual(startPos.y, endPos.y, "Player did not move vertically after pressing W.");

        keyboard = null;
    }
}