//terminamos clean code
//using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Level1SceneController : MonoBehaviour
{
    GameManager gameManager;        
    [SerializeField]
    TextMeshProUGUI fruitCountTMP;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.gameManager;
    }
    internal void UpdateFruitCountTMP()
    {
        fruitCountTMP.text = gameManager.fruitCount.ToString();

    }
    // Update is called once per frame
    void Update()
    {
        GameManager.gameManager.SetFruitCount(3);
    }
}
