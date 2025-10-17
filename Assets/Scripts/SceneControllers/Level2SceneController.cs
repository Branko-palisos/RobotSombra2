// terminamos clean code
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Level2SceneController : MonoBehaviour
{
    FruitBehaviour fruitBehaviour;  
    [SerializeField]
   internal GameObject  LoseSubmenu;
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

    // Update is called once per frame
    void Update()
    {
        gameManager.SetFruitCount(195); // for testing
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
        PlayerBehaviour.onPlayerDeath += DeathReceptor;
    }
    void OnDisable()
    {
        PlayerBehaviour.onPlayerDeath -= DeathReceptor;     
    }
}
