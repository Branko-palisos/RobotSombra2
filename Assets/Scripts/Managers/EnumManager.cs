// clean code completed!
using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class EnumManager : MonoBehaviour
{
   internal static EnumManager instance;

    internal enum Scenes
    {
        BananaScene,
        LevelLog,
        MainMenu,
        SettingsMenu,
        LevelMaker,
        Level1,
        Level2,
        SampleScene,

    };
    internal enum Generator
    {
        Game_Over,
        Its_ok,
        Better_Luck_Next_Time,
    }

    internal enum AnimatiorParameters
    {
        DanceTrigger,
        Fade,
    }
}
