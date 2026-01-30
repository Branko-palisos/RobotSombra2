// clean code completed!
//using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   Level1SceneController Level1SceneController;
   internal int fruitCount;
   internal TextMeshProUGUI DETAP;
    PlayerBehaviour playerBehaviour;
    int lastCompletedLevel = 0;
    internal static GameManager gameManager;
    //efuncisones
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        //    Debug.Log("Soy game manager y ya me assigne");
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);  
    }
    void Start()
    {
        // inmprimir nombre de la escena actual
        SceneManager.GetActiveScene();
        //Debug.Log(SceneManager.GetActiveScene().name);
    }
    private void Update()
    {
        if (!gameObject.activeSelf)
        {
            SceneManager.GetActiveScene();
        }
    }
    
   
    internal int GetFruitCount()
    {
        return fruitCount;
    }
    internal void SetFruitCount(int _amount)
    {
        fruitCount = _amount;
     //   Debug.Log($"FruitCount ={fruitCount}");
    }
    internal void ChangeLastLevelCompleted(int _amount)
    {
        lastCompletedLevel += _amount;
    }

    // Update is called once per frame;
    internal int GetLastCompletedLevel()
    {
        return lastCompletedLevel;
    }
    
    void OnEnable()
    {
       //PlayerBehaviour.onGotFruit += Level1SceneController.UpdateFruitCountTMP;
    }

    // para dejar de escuchar

    void OnDisable()

    {

       // PlayerBehaviour.onGotFruit -= Level1SceneController.UpdateFruitCountTMP;

    }
}
