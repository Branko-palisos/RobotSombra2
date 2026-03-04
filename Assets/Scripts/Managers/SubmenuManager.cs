using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SubmenuManager : MonoBehaviour
{
    private int min = 0;
    private int max = 3;
    [SerializeField]
    private TextMeshProUGUI gameOverTMP;
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
    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {

          
        }
    }
    internal void Win()
    {
      //  Debug.Log("Win");
      // Debug.Log("aparecer submenu");       
        winSubmenu.SetActive(true);
       
    }
    internal void Lose()
    {
        // activar submenu de perder
        loseSubmenu.SetActive(true);

        // obtener in numbero aleatorior con min y max
        int losingTextIndex = Random.Range(min, max);

        // obtener elemento alatorio al indice
        EnumManager.Generator losingText = (EnumManager.Generator)losingTextIndex;

        // substiour _'s por espacios
        string losingTextModifyied = losingText.ToString().Replace("_", " ");
      

        // asignar text por TMP
        gameOverTMP.text = losingTextModifyied.ToString();
    }
    public void NextLevelButton()
    {
        /*witch (SceneManager.GetActiveScene().name)
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
   */
    }
    public void ContinueButton()
        {
        Debug.Log("DCONTINUE button // antes"); 
        loseSubmenu.SetActive(false);
        
        Debug.Log("DCONTINUE button // after");
        if (SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level2.ToString()))
           {
        //    SceneManager.LoadScene(EnumManager.Scenes.Level2.ToString());
          
            Debug.Log("Disable Erkser");
           }


        }  
     public void Test()
    {
        print("test");
        gameObject.SetActive(false);
    }

    //  SceneManager.LoadScene(EnumManager.Scenes.Level2.ToString());
    // SceneManager.LoadScene(_newScene.ToString());
   
 }
