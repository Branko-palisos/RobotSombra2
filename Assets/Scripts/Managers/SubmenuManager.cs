using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SubmenuManager : MonoBehaviour
{
    
    GameManager gameManager;    
    internal static SubmenuManager submenuManager;
    [SerializeField]    
    GameObject winSubmenu;
    [SerializeField]
    GameObject loseSubmenu;
    [SerializeField]
     SceneController sceneController;
    // Start is called before the first frame update
    private void Awake()
    {
        winSubmenu.SetActive(false);        
        if (submenuManager == null)
        {
            submenuManager = this;
            
            
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }
   internal void Win()
    {
      //  Debug.Log("Win");
      // Debug.Log("aparecer submenu");       
        winSubmenu.SetActive(true);
       
    }
    internal void Lose()
    {
        Debug.Log("aparecer submenu lose");
        loseSubmenu.SetActive(true);    
    }
    public void NextLevelButton()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            //   case "Level1":
            case nameof(EnumManager.Scenes.Level1):
                Debug.Log(" next Level2"); 
               FindObjectOfType<SceneController>().ChangeScene(EnumManager.Scenes.Level2);
                break;
            case nameof(EnumManager.Scenes.Level2):
                sceneController.ChangeScene(EnumManager.Scenes.Level3);
                Debug.Log(" next Level3");
                break;
            case nameof(EnumManager.Scenes.Level3):
                sceneController.ChangeScene(EnumManager.Scenes.Level4);
                Debug.Log("next Level4");
                break;
            default:
                Debug.Log($"{SceneManager.GetActiveScene().name}Not found");
                break;
        }
       
        

        //  SceneManager.LoadScene(EnumManager.Scenes.Level2.ToString());
       // SceneManager.LoadScene(_newScene.ToString());
    } 
}
