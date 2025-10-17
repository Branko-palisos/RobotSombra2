// terminamos clean code
using System.Collections;
//using System.Collections.Generic;
//using System.Data.Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static EnumManager;
//using UnityEngine.UI;
//using static UnityEngine.RuleTile.TilingRuleOutput;
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    Level1SceneController Level1SceneController;
    SubmenuManager submenuManager;
    public GameObject nextLevelButton;
    [SerializeField]
    Level2SceneController level2SceneController;
    [SerializeField]    
    private TextMeshProUGUI gameOverTMP;
    internal delegate void OnGotFruit();
    internal static event OnGotFruit onGotFruit;
    internal delegate void OnPlayerDeath();
    internal static event OnPlayerDeath onPlayerDeath;
    private GameManager gameManager;
    [SerializeField]
    internal float speed = 5.0f;
    Vector3 growFactor = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 growLimit = new Vector3(2, 2, 2);
    private Animator animator;
    public bool bill = false;
    [SerializeField]
    private int min = 0;
    [SerializeField]    
    private int max = 3;
    private int waitBeforeChangeScene = 3;
    private int fruitCount = 3;
    [SerializeField]
    GameObject LoseText;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        fruitCount = 95;
        submenuManager = SubmenuManager.submenuManager;
    }
    void Update()
    {
      // Debug.Log("Esenca actual "   + SceneManager.GetActiveScene().name);
      //  Debug.Log("Esenca actual "  + (EnumManager.Scenes.Level1));
  
       
        if (SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level1.ToString()))     
        {
            Level1Movement();
       //     Debug.Log("Level 1");            
            //fruitCount = 3;       
       //     Debug.Log("Win");    
          //  animator.SetTrigger(EnumManager.AnimatiorParameters.DanceTrigger.ToString());
       //     SceneManager.LoadScene(EnumManager.Scenes.Level2.ToString());
        }
        // si el nombre de la escena actual es equal a nivel 1
      //  Debug.Log($"Escena actual: {SceneManager.GetActiveScene().name}");
        if (SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level2.ToString()))
        {
            Debug.Log("Call lvl 2 movement");
            Level2Movement();
        }
        Vector3 direction = new Vector3 (0,1,0);    
        Vector3 velocity  = direction * speed;       
    }
    void Level1Movement()
    {
      //  Debug.Log("Level1Movement");
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("move");
        }
        if (Input.GetKey("a"))
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            transform.position += new Vector3(0, 1 * speed * Time.deltaTime, 0);
        }
        if (Input.GetKey("s"))
        {
            transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
        }
    }
    void Level2Movement()
    {
        Debug.Log("Lewvel 2 movement");
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown("w"))
        {
           
            bill = true;
           
        }
        if (bill == true)
        {
            transform.position += new Vector3(0, 1 * speed * Time.deltaTime, 0);
        }
    }
    
   internal void GetFruit()
    {
        StartCoroutine(GetFruitCR());
    }
   internal IEnumerator GetFruitCR()
    {
     // nos quedamos aqui 
        fruitCount += 1;
        if (fruitCount > 99)
        {
           submenuManager.Win();
            fruitCount = 99;
           // Debug.Log("Win");
     //       FindObjectOfType<LevelLogSceneController>().ChangeLastLevelCompleted(1);
            //SceneManager.LoadScene("Level 2");     
          animator.SetTrigger(EnumManager.AnimatiorParameters.DanceTrigger.ToString());
           // level2SceneController.LoseSubmenu.gameObject.SetActive(true);
            yield return new WaitForSeconds(waitBeforeChangeScene);
            
          //  SceneManager.LoadScene(EnumManager.Scenes.Level2.ToString());
          
        }
        Grow();
        if (onGotFruit != null)
        {
            // mando la señal
               onGotFruit();
            
        }
        Level1SceneController.UpdateFruitCountTMP();
        Debug.Log("fruitCount = " + fruitCount);
    }    
    public void NextLevelButton()
    {
        Debug.Log("next level 2");
        SceneManager.LoadScene(EnumManager.Scenes.Level2.ToString());
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(EnumManager.Scenes.MainMenu.ToString());        
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(EnumManager.Scenes.Level1.ToString());       
    }
    public void MainMenuButtonLose()
    {
        SceneManager.LoadScene(EnumManager.Scenes.MainMenu.ToString());
    }
  public  void SoloImprimir()
    {     
            Debug.Log("MainMenu");         
    }
   internal float GetSpeed()
    {
        return speed;
    }
   internal void SetSpeed(float _amount)
    {
        speed = _amount;
    }
    internal void ChangeSpeed( float _change)
    {
        speed += _change;
    }
    public void Death()
    {
        StartCoroutine(DeathCorutine());
    }
 
    IEnumerator DeathCorutine()
    {
        Destroy(gameObject);
        if (onPlayerDeath != null)
        {

            onPlayerDeath();
        }
        //   gameOverTMP.text = EnumManager.Generator.losingText.ToString();
        int losingTextIndex = Random.Range(min,max);
        Debug.Log("losing text index "+ losingTextIndex);
        EnumManager.Generator losingText = (EnumManager.Generator)losingTextIndex;
       string  losingTextModifyied = losingText.ToString().Replace("_", " ");
        gameOverTMP.text = losingTextModifyied.ToString();
        submenuManager.Lose();
      //  Random.Range(min, max);
        GetComponent<SpriteRenderer>().enabled = false;
        animator.SetTrigger(EnumManager.AnimatiorParameters.Fade.ToString());
       // gameManager.DETAP.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitBeforeChangeScene);
        SceneManager.LoadScene(EnumManager.Scenes.SampleScene.ToString());

    }
    public void Grow()
    {
        transform.localScale += growFactor;
        if (transform.localScale.x > 2)
        {
            transform.localScale = growLimit;
        }
    }
}