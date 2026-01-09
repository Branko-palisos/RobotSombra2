using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3SceneController : SceneController
{
    // Start is called before the first frame update
    [SerializeField]
    internal GameObject LoseSubmenu;
    private void Awake()
    {
        LoseSubmenu.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DeathReceptor()
    {
        LoseSubmenu.SetActive(true);
    }
    void OnEnable()
    {
        PlayerBehaviour.onPlayerDeath += DeathReceptor;
    }

    void OnDisable()
    {
        PlayerBehaviour.onPlayerDeath -= DeathReceptor;
    }
}
