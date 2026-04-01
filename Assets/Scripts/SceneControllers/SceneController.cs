using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    protected GameManager gameManager;
    [SerializeField]
    protected SubmenuManager submenuManager;
    [SerializeField]
    TextMeshProUGUI Lv2FruitCount;
    // cambiar a general para todos los niveles
    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameManager = GameManager.gameManager;
        submenuManager = SubmenuManager.submenuManager;
        Debug.Log($"SubmenuManager.. {submenuManager}");
    //    Debug.Log("Asignar game manager");
}
   
    // Update is called once per frame
    internal void ChangeScene(EnumManager.Scenes _newScene)
    {
      SceneManager.LoadScene( _newScene.ToString());   
    }
    void DeathReceptor()
    {
        Debug.Log("Death Receptor");
       submenuManager.Lose();      
    }
     void UpdateFruitCountTMP()
    {
        Debug.Log("Update Fruit Count");
     //   Lv2FruitCount.text = gameManager.fruitCount.ToString();

    }
    protected virtual void OnEnable()
    {
        Debug.Log("Scene Controller OnEnable");
        FruitBehaviour.onGetFruit += UpdateFruitCountTMP;
        PlayerBehaviour.onPlayerDeath += DeathReceptor;
    }

   protected virtual void OnDisable()
    {
        FruitBehaviour.onGetFruit -= UpdateFruitCountTMP;
        PlayerBehaviour.onPlayerDeath -= DeathReceptor;
    }

}
