using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   protected GameManager gameManager;
   protected SubmenuManager submenuManager;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameManager = GameManager.gameManager;
        submenuManager = SubmenuManager.submenuManager;
    //    Debug.Log("Asignar game manager");
    }
    
    // Update is called once per frame
    internal void ChangeScene(EnumManager.Scenes _newScene)
    {
      SceneManager.LoadScene( _newScene.ToString());   
    }
}
