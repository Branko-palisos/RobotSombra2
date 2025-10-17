//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitBehaviour : MonoBehaviour
{ 
    SubmenuManager submenuManager;
     Level2SceneController level2SceneController;       
    private PlayerBehaviour playerBehaviour;
    private GameManager gameManager;        
    private int minX = -8;
    private int maxX = 8;
    private float minY = -3.5f;
    private float maxY = 3.5f;
    // funciones
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollidedWith =  " + collision.gameObject.name);
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
