// terminamos clean code
//using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Level1SceneController;

public class Level2SceneController : SceneController
{
    FruitBehaviour fruitBehaviour;      
    int fruitsToWin = 199;
    internal delegate void OnWin();
    internal static event OnWin onWin;
    PlayerBehaviour playerBehaviour;
    [SerializeField]
    TextMeshProUGUI fruitCountTMP;
    // Update is called once per frame
    void Update()
    {

        //   if (gameManager.GetFruitCount() > fruitsToWin)
         if (gameManager.FruitCount > fruitsToWin)


        {
            gameManager.DETAP.gameObject.SetActive(false);
            Debug.Log("Win");    
        }
    }  internal void UpdateFruitCountTMP()
    {
        //  Debug.Log($"Update Fruit Count = {gameManager.fruitCount }");
        fruitCountTMP.text = gameManager.fruitCount.ToString();

    }
    void CheckIfWin()
    {
        if (playerBehaviour.FruitCount > 199)
        {
            //  submenuManager.Win();                             
            ChangeScene(EnumManager.Scenes.Level3);
            if (onWin != null)
            {
                onWin();
            }
        }

    }
    protected override void OnEnable()
    {
        Debug.Log("Level1 Scene Controller On Enable");
        base.OnEnable();
        PlayerBehaviour.onGotFruit += CheckIfWin;
        FruitBehaviour.onGetFruit += UpdateFruitCountTMP;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        PlayerBehaviour.onGotFruit -= CheckIfWin;
        FruitBehaviour.onGetFruit -= UpdateFruitCountTMP;
    }
}
