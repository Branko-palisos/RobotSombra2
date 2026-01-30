using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

public class PlayerBehaviourl1 : PlayerBehaviour
{
    // Start is called before the first frame update
    internal static GameManager gameManager;
   protected override void Start()
    {
        
        if (!SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level1.ToString()))
        {
           
            return;
        }
    }
   
    // Update is called once per frame
    protected override void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level1.ToString()))
        {

            return;
        }
        base.Update();
    }
    protected override void Move()
    {
        Debug.Log("mover como Lv1 movement");

    }
}
