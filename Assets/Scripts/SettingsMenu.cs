using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    // public Resolution[] resolutions;
    [SerializeField]
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public TextMeshProUGUI volumeQuantity;
    [SerializeField]
    TMP_FontAsset font;

    [SerializeField]
     TextMeshProUGUI volumeTMP;
   void Start()
   { //var foundCanvasObjects = FindObjectsByType<CanvasRenderer>(FindObjectsSortMode.None);


        Fonts(1031);
        Screen.fullScreen = false;
       SetVolume();
       resolutions = Screen.resolutions;
       resolutionDropdown.ClearOptions();
       
       int currentResolutionIndex = 0;
        List<string> options = new List<string>();
       
        for (int i = 0; i < resolutions.Length; i++)
       {
           string option = resolutions[i].width + "x" + resolutions[i].height;
           options.Add(option);
           if (resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
           {

               currentResolutionIndex = i; 
           }
       }
       resolutionDropdown.AddOptions(options);
       resolutionDropdown.value = currentResolutionIndex;
       resolutionDropdown.RefreshShownValue();
   }
    public void Fonts(int fontIndex)
    {
        TextMeshProUGUI[] texts = FindObjectsByType<TextMeshProUGUI>(FindObjectsSortMode.None);
        foreach (TextMeshProUGUI text in texts)
        {
            // Haz algo con cada objeto, por ejemplo, activar un componente
           // Debug.Log("" + text);
            Debug.Log(fontIndex);
            text.font = font;
        }
      
    }
  public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;       
        
    }
   // Update is called once per frame

   void Update()
   {

   }
   public void SetVolume ()
   {
       audioMixer.SetFloat("volume", volumeSlider.value);
       int volumeQuantityTemp = ((int)volumeSlider.value + 20) * 5;
       volumeQuantity.text = volumeQuantityTemp.ToString();

   }    
public void SetResolution(int resolutionIndex)
   {
       Resolution resolution = resolutions[resolutionIndex];
        Debug.Log("resolution");
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
   } 
   public void SetQuality (int qualityIndex)
   {
      
       QualitySettings.SetQualityLevel(qualityIndex);
   }

} 
