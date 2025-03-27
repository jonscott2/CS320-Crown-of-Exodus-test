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

    //public static Vector3 playerPos = Vector3.zero;
    //public static Quaternion playerDir = Quaternion.identity;
    //GameObject player = GameObject.Instantiate(playerPrefab, playerPos, playerDir);


    [Test]
    
    public void ExampletestscriptSimplePasses()
    {
        // Use the Assert class to test conditions
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
