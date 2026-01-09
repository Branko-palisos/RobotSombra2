//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitBehaviour : MonoBehaviour
{
    internal delegate void GetFruit();
    internal static event GetFruit onGetFruit;
    SubmenuManager submenuManager;
     Level2SceneController level2SceneController;       
    private PlayerBehaviour playerBehaviour;
    private GameManager gameManager;        
    private float minX = -6.5f;
    private float maxX = 7f;
    private float minY = -3.5f;
    private float maxY = 3.5f;
    // funciones
    private void Start()
    {
       gameManager = GameManager.gameManager;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       
        Debug.Log("CollidedWith =  " + collision.gameObject.name);
        gameManager.SetFruitCount(gameManager.GetFruitCount() + 1);
        if (onGetFruit != null)
        {
            //Debug.Log("Send signal");
            // mando la señal
            onGetFruit();

        }
        // sharky.GetComponent<PlayerBehaviour>().GetFruit();
        playerBehaviour = collision.gameObject.GetComponent<PlayerBehaviour>();     
        playerBehaviour.GetFruit();
        gameObject.SetActive(false);

        transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        gameObject.SetActive(true);

        if (SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level2))
        {

            Debug.Log("speed up");
            //    playerBehaviour.speed += 0.8f;
            //  playerBehaviour.SetSpeed(playerBehaviour.GetSpeed() + 0.8f);
            playerBehaviour.ChangeSpeed(0.8f);

        }
        //      if (playerBehaviour.fruitCount == 3.0f )
     //   if (gameManager.GetFruitCount() == 3.0f )
        {

           // Debug.Log("Win");
        }
        // if(gameManager.GetFruitCount() == 99.0f)
        {
            // submenuManager.Win();
        }
    }
}