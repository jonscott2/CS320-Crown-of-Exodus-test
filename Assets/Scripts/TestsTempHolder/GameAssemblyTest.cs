//using System.Collections;
//using System.Collections.Generic;
//using NUnit.Framework;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.TestTools;
//using static UnityEngine.UI.CanvasScaler;

//public class GameAssemblyTest
//{
//    GameObject playerPrefab = Resources.Load<GameObject>("Player");

//    // A Test behaves as an ordinary method
//    [Test]
//    public void TestPlayerDamage()
//    {


//    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
//    public class BattleSystem : MonoBehaviour
//    {
//        public BattleState state;

//        public GameObject playerPrefab;
//        public GameObject enemyPrefab;

//        //Button GameObject Variables
//        public GameObject healButton;
//        public GameObject akeruHealButton;
//        public GameObject attackButton;
//        public GameObject akeruAttackButton;
//        public GameObject meleeButton;
//        public GameObject akeruBlackMagic;
//        public GameObject akeruSword;
//        public GameObject akeruSpecial;

//        public Transform playerBattleSystem;
//        public Transform enemyBattleSystem;

//        //public string sceneToChangeTo = GameManager.instance.prevScene;

//        //public TransitionToBattle transitionToBattle;

//        public Vector3 lastPlayerposition;

//        Unit playerUnit;
//        Unit enemyUnit;

//         IEnumerator SetupBattle()
//        {

//            GameObject playerGO = Instantiate(playerPrefab, playerBattleSystem);
//            playerUnit = playerGO.GetComponent<Unit>();

//            GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleSystem);
//            enemyUnit = enemyGO.GetComponent<Unit>();
//            playerHud.SetHUD(playerUnit);
//            enemyHud.SetHUD(enemyUnit);

//            yield return new WaitForSeconds(3f);
//        }

//        StartCoroutine(SetupBattle());
//        currentScene = SceneManager.GetActiveScene().name;

//    }

//        playerUnit.TakeDamage(enemyUnit.damage);
//    }
//}

//    public void GameAssemblyTestSimplePasses()
//    {
//        // Use the Assert class to test conditions
//    }

//    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
//    // `yield return null;` to skip a frame.
//    [UnityTest]
//    public IEnumerator GameAssemblyTestWithEnumeratorPasses()
//    {
//        // Use the Assert class to test conditions.
//        // Use yield to skip a frame.
//        yield return null;
//    }
//}
