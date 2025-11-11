using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    TMP_FontAsset[] font;
    int currentFontIndex = 0;
    internal static TextManager textManager;
    // Start is called before the first frame update
    private void Awake()
    {
        if (textManager == null)
        {
            textManager = this;
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
    public void UpdateFonts()
    {
        TextMeshProUGUI[] texts = FindObjectsByType<TextMeshProUGUI>(FindObjectsSortMode.None);
        foreach (TextMeshProUGUI text in texts)
        {
            // Haz algo con cada objeto, por ejemplo, activar un componente
            // Debug.Log("" + text);
            Debug.Log(font);
            text.font = font[currentFontIndex];
            //    Debug.Log(texts);    
        }

    }
    public void SetFont(int _currentFontIndex)
    {
        currentFontIndex = _currentFontIndex;
        UpdateFonts();
    }
       
}
