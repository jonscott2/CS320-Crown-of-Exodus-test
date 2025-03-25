using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using static UnityEngine.UI.CanvasScaler;

public class GameAssemblyTest
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");

    // A Test behaves as an ordinary method
    [Test]
    public void TestPlayerDamage()
    {
        public class BattleHUD : MonoBehaviour
    {
        public Text nameText;
        public Text levelName;
        public Slider hpSilder;

        public void SetHUD(Unit Unit)
        {
            nameText.text = Unit.unitName;
            levelName.text = "Lvl " + Unit.unitLevel;
            hpSilder.maxValue = Unit.maxHP;
            hpSilder.value = Unit.currentHP;
        }

        public void SetHP(int hp)
        {
            hpSilder.value = hp;
        }
    }


    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
    public class BattleSystem : MonoBehaviour
    {
        public BattleState state;

        public GameObject playerPrefab;
        public GameObject enemyPrefab;

        //Button GameObject Variables
        public GameObject healButton;
        public GameObject akeruHealButton;
        public GameObject attackButton;
        public GameObject akeruAttackButton;
        public GameObject meleeButton;
        public GameObject akeruBlackMagic;
        public GameObject akeruSword;
        public GameObject akeruSpecial;

        public Transform playerBattleSystem;
        public Transform enemyBattleSystem;

        public BattleHUD playerHud;
        public BattleHUD enemyHud;

        public Unit playerExp;

        //public string sceneToChangeTo = GameManager.instance.prevScene;

        //public TransitionToBattle transitionToBattle;

        public Vector3 lastPlayerposition;

        public string currentScene;
        public static string lastScene;

        private bool akeruTurn = false;
        private bool oneMore;

        public bool enemyDefeated = false;

        Unit playerUnit;
        Unit enemyUnit;

        //ExperienceManager enemyManager;
        DeleteEnemy enemyMask;
        public int levelNum = 1;
        public int expEarned = 200;
        public float RadNum = 0f;


        //setting up
        oneMore = false;
        state = BattleState.START;
        attackButton.SetActive(true);
        healButton.SetActive(true);
        akeruHealButton.SetActive(false);
        akeruAttackButton.SetActive(false);
        akeruSword.SetActive(false);
        meleeButton.SetActive(false);
        // enemyManager = GameObject.Find("ExperienceManager").GetComponent<ExperienceManager>();
        StartCoroutine(SetupBattle());
        currentScene = SceneManager.GetActiveScene().name;

    }

        playerUnit.TakeDamage(enemyUnit.damage);
    }

    public void GameAssemblyTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator GameAssemblyTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
