// clean code completed!
//using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]    
    TextMeshProUGUI fruitCountTMP;
   Level1SceneController Level1SceneController;
   internal float fruitCount;
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
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);  
    }
    void Start()
    {
      
        if( gameManager == null)
        {
            gameManager = this;     
        }
        // inmprimir nombre de la escena actual
        SceneManager.GetActiveScene();
        //Debug.Log(SceneManager.GetActiveScene().name);
    }
    private void Update()
    {
        
    }
    
   
    internal float GetFruitCount()
    {
        return fruitCount;
    }
    internal void SetFruitCount(int _amount)
    {
        fruitCount = _amount;       
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
