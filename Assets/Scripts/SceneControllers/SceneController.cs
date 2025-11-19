using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   protected GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.gameManager;
       // Debug.Log("Asignar game manager");
    }
    
    // Update is called once per frame
    protected void ChangeScene(EnumManager.Scenes _newScene)
    {
      SceneManager.LoadScene( _newScene.ToString());   
    }
}
