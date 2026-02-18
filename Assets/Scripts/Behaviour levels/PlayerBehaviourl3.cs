using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviourl3 : PlayerBehaviour
{
    protected override void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level3.ToString()))
        {

            return;
        }


    }
    protected override void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals(EnumManager.Scenes.Level3.ToString()))
        {

            return;
        }
        base.Update();
    }


    protected override void Move()
    {
        Debug.Log("mover como Lv3 movement");
    }
}
