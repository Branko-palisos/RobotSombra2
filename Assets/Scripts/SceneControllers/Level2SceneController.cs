// terminamos clean code
//using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level2SceneController : SceneController
{
    FruitBehaviour fruitBehaviour;      
    int fruitsToWin = 199;
    // Update is called once per frame
    void Update()
    {
       
        if (gameManager.GetFruitCount() > fruitsToWin)
        {
            gameManager.DETAP.gameObject.SetActive(false);
            Debug.Log("Win");    
        }
    }
    
   
}
