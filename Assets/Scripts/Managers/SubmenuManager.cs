using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SubmenuManager : MonoBehaviour
{
    
    GameManager gameManager;    
    internal static SubmenuManager submenuManager;
    [SerializeField]    
    GameObject winSubmenu;
    [SerializeField]
    GameObject loseSubmenu;
    // Start is called before the first frame update
    private void Awake()
    {
        winSubmenu.SetActive(false);        
        if (submenuManager == null)
        {
            submenuManager = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }
   internal void Win()
    {
      //  Debug.Log("Win");
       Debug.Log("aparecer submenu");       
        winSubmenu.SetActive(true);
       
    }
    internal void Lose()
    {
        Debug.Log("aparecer submenu lose");
        loseSubmenu.SetActive(true);    
    }
}
