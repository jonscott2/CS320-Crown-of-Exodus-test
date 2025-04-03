using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Player
{
    // A Test behaves as an ordinary method

    public static GameObject playerPrefab = Resources.Load<GameObject>("Player");

    public static GameObject player = GameObject.Instantiate(playerPrefab);

    public static TransitionToBattle BattleScript = (TransitionToBattle.instance);

    //new TransitionToBattle();


    [Test]
    public void PlayerSimplePasses()
    {
        // Use the Assert class to test conditions
        Assert.IsNotNull(BattleScript.lastScene, "Battle Scene is not working");
        Assert.That(BattleScript.isNextScene, Is.EqualTo(true), "Is next scene not working");
        Assert.That(BattleScript.sceneToLoad, Is.EqualTo("Battle Scene slime"), "Scene loading string not working");



    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayerWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
