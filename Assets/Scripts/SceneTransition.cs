using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject fadeInPanel; 
    public GameObject fadeOutPanel;
    public GameObject enemyCheck;
    public float fadeWait;
    public bool isNextScene = true;
//[SerializeField]
    //public SceneInfo sceneInfo;
   // public bool enemyCurrentStateWin;

    private void Start()
    {
        //enemyCheck.SetActive(true);
       // enemyCurrentStateWin = false;
    }

    private void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            //sceneInfo.isNextScene = isNextScene;
            StartCoroutine(FadeCo() );
            SceneManager.LoadScene(sceneToLoad);

        }
    }

    public IEnumerator FadeCo()
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
           // enemyCheck.SetActive(false);
           // enemyCurrentStateWin = true;
            yield return null;
        }
    }

}
