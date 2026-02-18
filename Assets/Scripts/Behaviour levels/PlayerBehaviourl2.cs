using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PlayerBehaviourl2 : PlayerBehaviour
{
    // Start is called before the first frame update
    protected override void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level2.ToString()))
        {

            return;
        }


    }
    protected override void Update() { 
       if (!SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level2.ToString()))
        {

            return;
        }
        base.Update();
    }

    
    protected override void Move()
    {
        Debug.Log("mover como Lv2 movement");
    }
    // Update is called once per frame

}
