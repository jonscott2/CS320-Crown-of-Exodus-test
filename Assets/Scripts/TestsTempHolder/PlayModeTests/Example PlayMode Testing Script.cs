using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ExamplePlayModeTestingScript
{
    public static GameObject playerPrefab = Resources.Load<GameObject>("Player");

    public static GameObject player = GameObject.Instantiate(playerPrefab);

    //SceneManager.loadscene

    // A Test behaves as an ordinary method
    [Test]
    public void ExamplePlayModeTestingScriptSimplePasses()
    {

        // Use the Assert class to test conditions
    }

    public IEnumerator TestingPlayerMovement()
    {
        player.AddComponent<Rigidbody>();
        var originalPosition = player.transform.position.y;

        yield return new WaitForFixedUpdate();

        Assert.AreNotEqual(originalPosition, player.transform.position.y);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ExamplePlayModeTestingScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
