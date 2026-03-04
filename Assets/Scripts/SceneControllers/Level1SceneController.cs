//terminamos clean code
//using System.Collections;
//using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class Level1SceneController : SceneController
{
    internal delegate void OnWin();
    internal static event OnWin onWin;
    PlayerBehaviour playerBehaviour;
    [SerializeField]
    TextMeshProUGUI fruitCountTMP;
   
    // Start is called before the first frame update
    protected override void Start()
    { 
        base.Start();
        // cambiar numbero de frutas
        gameManager.SetFruitCount(gameManager.GetFruitCount() + 95);
        //actualizar el TMP
        UpdateFruitCountTMP();
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
    }

    internal void UpdateFruitCountTMP()
    {
        Debug.Log($"Update Fruit Count = {gameManager.fruitCount }");
        fruitCountTMP.text = gameManager.fruitCount.ToString();

    }
    void CheckIfWin()
    {
        if (playerBehaviour.FruitCount > 99)
        {
             submenuManager.Win();                             
             ChangeScene(EnumManager.Scenes.Level2);
            if (onWin != null)
            {
                onWin();
            }
        }
      
    }
    // Update is called once per frame
    void Update()
    {
   
    }
    void OnEnable()
    {
        PlayerBehaviour.onGotFruit += CheckIfWin;
        FruitBehaviour.onGetFruit += UpdateFruitCountTMP;
    }
    void OnDisable()
    {
        PlayerBehaviour.onGotFruit -= CheckIfWin;
        FruitBehaviour.onGetFruit -= UpdateFruitCountTMP;
    }
    
}