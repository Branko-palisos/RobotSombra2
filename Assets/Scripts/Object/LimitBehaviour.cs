// clean code completed
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class LimitBehaviour : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerBehaviour>().Death();
        Debug.Log("Lose");
        Debug.Log("Win = 195");
    }
}
