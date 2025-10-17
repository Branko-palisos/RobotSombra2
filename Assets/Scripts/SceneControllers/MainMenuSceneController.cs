// terminaos clean code
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneController : MonoBehaviour
{
    [SerializeField]
    GameObject settingsSubmenu;
    public void LevelLog()
    {
        SceneManager.LoadScene(EnumManager.Scenes.LevelLog.ToString());
       // Debug.Log("LevelScene");
    }
    public void BananaScene()
    {
        SceneManager.LoadScene(EnumManager.Scenes.BananaScene.ToString());
       // Debug.Log("LevelScene");
    }
    public void LevelMaker()
    {
        SceneManager.LoadScene(EnumManager.Scenes.LevelMaker.ToString());   
    }
    public void ExitFuncion()
    {
       // Debug.Log("Exit");
        Application.Quit();
    }
    public void SettingsMenu()
    {
        SceneManager.LoadScene(EnumManager.Scenes.SettingsMenu.ToString());
    }
    public void ExitSettingsMenu()
    {
          settingsSubmenu.SetActive (false); 
    }
    public void Level1()
    {
        SceneManager.LoadScene(EnumManager.Scenes.Level1.ToString());
       // Debug.Log("Level1");      
    }
    public void Level2()
    {
        SceneManager.LoadScene(EnumManager.Scenes.Level2.ToString());
      //  Debug.Log("Level2");
       if (Input.GetKey("w"))
        {
         //   Debug.Log("Level 2");
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(EnumManager.Scenes.MainMenu.ToString());
    }
    public void Share()
    {
      //  Debug.Log("Share");
    }
}
