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
        currentSpeed = startspeed;
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
        //  Debug.Log("Level1Movement");
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(1 * currentSpeed * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            //  Debug.Log("move");           
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
        if (Input.GetKeyDown("z"))
        {
            currentSpeed = highSpeed;
        }
        if (Input.GetKeyUp("z"))
        {
            currentSpeed = startspeed;
        }
    }
}
