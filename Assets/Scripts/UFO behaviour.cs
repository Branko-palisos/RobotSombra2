using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFObehaviour : MonoBehaviour
{
    internal float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("move");
        }
        if (Input.GetKey("a"))
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            transform.position += new Vector3(0, 1 * speed * Time.deltaTime, 0);
        }
        if (Input.GetKey("s"))
        {
            transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
        }
    }
}
