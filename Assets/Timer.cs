using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    PlayerBehaviour playerBehaviour;
    SubmenuManager submenuManager;
    [SerializeField]
    GameObject loseSubmenu;
    float currentTime;
    public float startingTime = 30f;
    [SerializeField]
    TextMeshProUGUI countdownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
       currentTime -= 1 * Time.deltaTime;
       countdownText.text = currentTime.ToString("0");    
        if(currentTime <= 0)
        {
            currentTime = 0;
            playerBehaviour.Win();

        }
        
    }
}
