//terminamos clean code
//using System.Collections;
//using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;


public class Level1SceneController : SceneController
{

    [SerializeField]
    TextMeshProUGUI fruitCountTMP;
    // Start is called before the first frame update

    internal void UpdateFruitCountTMP()
    {
        Debug.Log("Update Fruit Count");
        fruitCountTMP.text = gameManager.fruitCount.ToString();

    }
    // Update is called once per frame
    void Update()
    {
   
    }
    void OnEnable()
    {
        FruitBehaviour.onGetFruit += UpdateFruitCountTMP;
    }
    void OnDisable()
    {
        FruitBehaviour.onGetFruit -= UpdateFruitCountTMP;
    }
}