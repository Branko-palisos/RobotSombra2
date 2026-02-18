using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviourl4 : PlayerBehaviour
{
    protected override void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level4.ToString()))
        {

            return;
        }


    }
    protected override void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level4.ToString()))
        {

            return;
        }
        base.Update();
    }


    protected override void Move()
    {
        Debug.Log("mover como Lv4 movement");
    }
    // Update is called once per frame

}
