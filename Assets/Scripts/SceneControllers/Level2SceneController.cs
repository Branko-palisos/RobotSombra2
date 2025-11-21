// terminamos clean code
//using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level2SceneController : MonoBehaviour
{
    FruitBehaviour fruitBehaviour;  
    [SerializeField]
   internal GameObject  LoseSubmenu;
    [SerializeField]
    TextMeshProUGUI Lv2FruitCount;
    // Start is called before the first frame update
    GameManager gameManager;
    int fruitsToWin = 199;
    private void Awake()
    {
        LoseSubmenu.SetActive(false);
    }
    void Start()
    {
        gameManager = GameManager.gameManager;
    }
    internal void UpdateFruitCountTMP()
    {
        Debug.Log("Update Fruit Count");
        Lv2FruitCount.text = gameManager.fruitCount.ToString();

    }
    // Update is called once per frame
    void Update()
    {
        gameManager.SetFruitCount(0); // for testing
        if (gameManager.GetFruitCount() > fruitsToWin)
        {
            gameManager.DETAP.gameObject.SetActive(false);
            Debug.Log("Win");    
        }
    }
    void DeathReceptor()
    {
        LoseSubmenu.SetActive(true);
    }
    void OnEnable()
    {
        FruitBehaviour.onGetFruit += UpdateFruitCountTMP;
    }
   
    void OnDisable()
    {
        PlayerBehaviour.onPlayerDeath -= DeathReceptor;     
    }
}
