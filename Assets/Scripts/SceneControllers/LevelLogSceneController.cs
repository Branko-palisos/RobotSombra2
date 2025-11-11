using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogSceneController : MonoBehaviour
{
    [SerializeField]
    TextManager textManager;
    // Start is called before the first frame update
    void Start()
    {
        textManager = TextManager.textManager;
        textManager.UpdateFonts();
    }

    
}
