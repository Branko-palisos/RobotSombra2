// haciendo clean code
//using Unity.VisualScripting;
//using System.Collections.Generic;
//using System.Data.Common;
//using UnityEngine.UI;
//using static UnityEngine.RuleTile.TilingRuleOutput;
//using static EnumManager;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    public Transform target;
    public float speed = 7.0f;
    public GameObject explosion;
    public float rotateSpeed = 200.0f;
    public GameObject explosionEffect;
    public int health = 100;
    SubmenuManager submenuManager;
    [SerializeField]
     GameObject nextLevelButton;
    [SerializeField]
    Level2SceneController level2SceneController;
  
    internal delegate void OnGotFruit();
    internal static event OnGotFruit onGotFruit;
    internal delegate void OnPlayerDeath();
    internal static event OnPlayerDeath onPlayerDeath;
    private GameManager gameManager;
    [SerializeField]
   protected  float startspeed = 5.0f;
    [SerializeField]    
    protected float currentSpeed;
    protected float highSpeed = 8.0f;
    Vector3 growFactor = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 growLimit = new Vector3(2, 2, 2);
    private Animator animator;
   
    [SerializeField]
    private float rbSpeed = 30.0f;
    private int waitBeforeChangeScene = 3;
    public Rigidbody2D rb;
    private Vector3 direction;
    public float runSpeed;
    [SerializeField]
     int jump = 30;
 
    // Start is called before the first frame update
    private void Awake()
    {
      //  Debug.Log("Awake");
        animator = GetComponent<Animator>();
        //submenuManager = SubmenuManager.submenuManager;
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
       
       
       // currentSpeed = startspeed;
       Awake(); 
       // Debug.Log($"{SceneManager.GetActiveScene().name}");
    }
    protected virtual void Update()
    {
        Move();

        
        // Debug.Log("Esenca actual "   + SceneManager.GetActiveScene().name);
        //  Debug.Log("Esenca actual "  + (EnumManager.Scenes.Level1));
        if(SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level4.ToString()))
        {
            Level4Movement();
            
        }
        if (SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.BossFight.ToString()))
        {
            Level5Movement();
            void FixedUpdate()
            {
                Vector2 direction = (Vector2)target.position - rb.position;
                direction.Normalize();
                float rotateAmount = Vector3.Cross(direction, transform.up).z;
                rb.angularVelocity = -rotateAmount * rotateSpeed;
                rb.velocity = transform.up * speed;

            }
            void OnTriggerEnter2D()
            {
                explosion.SetActive(true);
                Instantiate(explosionEffect, transform.position, transform.rotation);
                Destroy(gameObject);
                Debug.Log("Explosion");
            }

        }
        if (SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level2.ToString()))
        {
            //  direction = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);
            //  Debug.Log("Call lvl 2 movement");
            Level2Movement();
        }

        // si el nombre de la escena actual es equal a nivel 1
        //  Debug.Log($"Escena actual: {SceneManager.GetActiveScene().name}");
        //   Transform playerTransform = GetComponent<Transform>();
        //    playerTransform.Translate(Vector2.right * Input.GetAxisRaw("Horizontal") * runSpeed * Time.deltaTime);

        Vector3 velocity  = direction * currentSpeed;
        
    }
    protected virtual void Move()
    {
       // Debug.Log("mover base");

    }
   
    void Level2Movement()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
          //  return;
        }
       
        //float movimientoHorizontal = Input.GetAxis("Horizontal");
     //  float movimientoVertical = Input.GetAxis("Vertical");
        if(Input.GetKeyDown("a"))
        {
          //  Debug.Log("move left");
            transform.eulerAngles = new Vector3(0, -180, 0);
           rb.velocity = new Vector3(-rbSpeed, 0, 0);
            Debug.Log($"rbSpeed{rbSpeed}");
        }    
        if(Input.GetKeyDown("d"))
        {
           // Debug.Log("move right");
            rb.velocity = new Vector3(rbSpeed, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }    
        if (Input.GetKeyDown("w"))
        {
            //Debug.Log("move up");
            rb.velocity = new Vector3(0, rbSpeed, 0);
        }
        if (Input.GetKeyDown("s"))
        {
           // Debug.Log("move down");
            rb.velocity = new Vector3(0, -rbSpeed, 0);
        }

       // Debug.Log("Fixed Update");
    //    Debug.Log("Horizontal movement" + movimientoHorizontal);
        //rb.velocity = new Vector3(movimientoHorizontal, movimientoVertical, 0) * currentSpeed;
       // Debug.Log("Level 2 movement");
      
        if (currentSpeed == 0)
        {
           // movimientoHorizontal = 5;
           // movimientoVertical = 5; 
        }
        if (currentSpeed != 0)
        {
           // movimientoHorizontal = 0;
          //  movimientoVertical = 0;
        }
        
      /*  if (Input.GetKey("d"))
        {
            transform.position += new Vector3(1 * currentSpeed * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            transform.position += new Vector3(-1 * currentSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown("w"))
        {
           
            bill = true;
           
        }
        if (bill == true)
        {
            transform.position += new Vector3(0, 1 * currentSpeed * Time.deltaTime, 0);
        }
      */
    } 
   /*public void Level3Movement()
    {
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(1 * currentSpeed * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("move");
        }
        if (Input.GetKey("a"))
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            transform.position += new Vector3(-1 * currentSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            transform.position += new Vector3(0, 1 * currentSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("s"))
        {
            transform.position += new Vector3(0, -1 * currentSpeed * Time.deltaTime, 0);
        }
    } */
   private void Level4Movement()
    {
        Debug.Log("Level4 Movement");
        if (Input.GetKey("d"))
        {
            Debug.Log("UNERSY current speed");
            transform.position += new Vector3(1 * currentSpeed * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
            Debug.Log("move");
        }
        if (Input.GetKey("a"))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position += new Vector3(-1 * currentSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown ("w"))
        {
            rb.AddForce(Vector3.up * jump);
        }
        if (Input.GetKey("s"))
        {
            transform.position += new Vector3(0, -1 * currentSpeed * Time.deltaTime, 0);
        }
        Debug.Log("UNERSY Level 4");
    }
    private void Level5Movement()
    {
        Debug.Log("Level4 Movement");
        if (Input.GetKeyDown("a"))
        {
            //  Debug.Log("move left");
            transform.eulerAngles = new Vector3(0, -180, 0);
            rb.velocity = new Vector3(-rbSpeed, 0, 0);
            Debug.Log($"rbSpeed{rbSpeed}");
        }
        if (Input.GetKeyDown("d"))
        {
            // Debug.Log("move right");
            rb.velocity = new Vector3(rbSpeed, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown("w"))
        {
            //Debug.Log("move up");
            rb.velocity = new Vector3(0, rbSpeed, 0);
        }
        if (Input.GetKeyDown("s"))
        {
            // Debug.Log("move down");
            rb.velocity = new Vector3(0, -rbSpeed, 0);
        }
        Debug.Log("UNERSY Level 4");
    }
    internal void GetFruit()
    {
  //      StartCoroutine(GetFruitCR());
    }
 //  internal IEnumerator GetFruitCR()
   // {
           
     //   if (SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level2.ToString()))
     //   {
          //  fruitCount = 199;
            //revisar si se accupa
      //  }
       // Grow();
      //  if (onGotFruit != null)
      //  {
            // mando la señal
          //     onGotFruit();
              
  //      }
        //Debug.Log("fruitCount = " + fruitCount);
   // }    
   internal void Win()
    {
        animator.SetTrigger(EnumManager.AnimatiorParameters.DanceTrigger.ToString());
    }
 
    public void MainMenuButton()
    {
        SceneManager.LoadScene(EnumManager.Scenes.MainMenu.ToString());        
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
        return currentSpeed;
    }

    internal void ChangeSpeed(float _change)
    {
        currentSpeed += _change;
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
        //      gameOverTMP.text = EnumManager.Generator.losingText.ToString();

        // Debug.Log("losing text index "+ losingTextIndex);
        
       // submenuManager.Lose();
      //  Random.Range(min, max);
        GetComponent<SpriteRenderer>().enabled = false;
        animator.SetTrigger(EnumManager.AnimatiorParameters.Fade.ToString());
       // gameManager.DETAP.gameObject.SetActive(true);
       yield return new WaitForSeconds(waitBeforeChangeScene);
      //  SceneManager.LoadScene(EnumManager.Scenes.SampleScene.ToString());

    }
    internal int FruitCount
    {
        get
        {
            return gameManager.fruitCount;
        }
        set
        {
            gameManager.fruitCount = value;
        }
    }
    private void OnEnable()
    {
       
        Level1SceneController.onWin += Win;
    }
    private void OnDisable()
    {
        Level1SceneController.onWin -= Win;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
