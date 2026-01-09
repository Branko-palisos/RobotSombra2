// terminaos clean code
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class MainMenuSceneController : SceneController   
{
    [SerializeField]
    GameObject settingsSubmenu;
    public void LevelLog()
    {
        ChangeScene(EnumManager.Scenes.LevelLog);
       // Debug.Log("LevelScene");
    }
    public void BananaScene()
    {     
      ChangeScene(EnumManager.Scenes.BananaScene);
       // Debug.Log("LevelScene");
    }
    public void LevelMaker()
    {
        ChangeScene(EnumManager.Scenes.LevelMaker);   
    }
    public void ExitFuncion()
    {
       // Debug.Log("Exit");
        Application.Quit();
    }
    public void SettingsMenu()
    {
        ChangeScene(EnumManager.Scenes.SettingsMenu);
    }
    public void ExitSettingsMenu()
    {
          settingsSubmenu.SetActive (false); 
    }
    public void Level1()
    {
        ChangeScene(EnumManager.Scenes.Level1);
       // Debug.Log("Level1");      
    }
    public void Level2()
    {
        ChangeScene(EnumManager.Scenes.Level2);
      //  Debug.Log("Level2");
       if (Input.GetKey("w"))
        {
         //   Debug.Log("Level 2");
        }
    }
    public void Level3()
    {
        ChangeScene(EnumManager.Scenes.Level3);
        
    }    
    public void Level4()
    {
        ChangeScene(EnumManager.Scenes.Level4);
    }
   
    public void MainMenu()
    {
        ChangeScene(EnumManager.Scenes.MainMenu);
    }
    public void Share()
    {
      //  Debug.Log("Share");
    }
}
