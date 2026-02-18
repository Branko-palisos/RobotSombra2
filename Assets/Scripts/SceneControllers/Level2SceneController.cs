// terminamos clean code
//using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level2SceneController : SceneController
{
    FruitBehaviour fruitBehaviour;  
    [SerializeField]
   internal GameObject  LoseSubmenu;
    [SerializeField]
    TextMeshProUGUI Lv2FruitCount;
    [SerializeField]
    GameObject LoseText;
    [SerializeField]
    private TextMeshProUGUI gameOverTMP;
    [SerializeField]
    private int min = 0;
    [SerializeField]
    private int max = 3;
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
       
        if (gameManager.GetFruitCount() > fruitsToWin)
        {
            gameManager.DETAP.gameObject.SetActive(false);
            Debug.Log("Win");    
        }
    }
    void DeathReceptor()
    {
        Debug.Log("Hercha of losing");
        int losingTextIndex = Random.Range(min, max);
        LoseSubmenu.SetActive(true);
        EnumManager.Generator losingText = (EnumManager.Generator)losingTextIndex;
        string losingTextModifyied = losingText.ToString().Replace("_", " ");
        gameOverTMP.text = losingTextModifyied.ToString();
    //    test.SetActive(true);
    }
    void OnEnable()
    {
        FruitBehaviour.onGetFruit += UpdateFruitCountTMP;
        PlayerBehaviour.onPlayerDeath += DeathReceptor;
    }
   
    void OnDisable()
    {
        FruitBehaviour.onGetFruit -= UpdateFruitCountTMP;
        PlayerBehaviour.onPlayerDeath -= DeathReceptor;     
    }
}
