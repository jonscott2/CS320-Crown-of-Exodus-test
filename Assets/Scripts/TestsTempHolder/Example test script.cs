using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Exampletestscript
{
    // A Test behaves as an ordinary method
    //setting up. Must be up here
    //creates a playerPrefab object to test

    public static GameObject playerPrefab = Resources.Load<GameObject>("Player");

    public static GameObject player = GameObject.Instantiate(playerPrefab);

    int health2 = player.GetComponent<Unit>().currentHP;

    [Test]
    
    public void ExampletestscriptSimplePasses()
    {
    Assert.IsNotNull(playerPrefab, "Player prefab not found in Resources");
    GameObject player = GameObject.Instantiate(playerPrefab);
    //checks that player game object is running correctly.
    Assert.IsNotNull(player, "Player is not working");

    Assert.That(health2, Is.EqualTo(25f));
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ExampletestscriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
