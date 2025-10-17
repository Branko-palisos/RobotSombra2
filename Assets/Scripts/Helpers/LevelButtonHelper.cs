//clean code completed!
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LevelButtonHelper : MonoBehaviour
{
    GameManager gameManager;    
    [SerializeField]    
    int myLevel;
    void Start()
    {
        gameManager = GameManager.gameManager;
        Disable();   
    }
    private void Disable()
    {
        if (myLevel <= gameManager.GetLastCompletedLevel()+1)
        {           
            //Debug.Log("Active");
        }
        else
        {
          //  Debug.Log("Disabled");
            Destroy(gameObject);
        }
    }
}
