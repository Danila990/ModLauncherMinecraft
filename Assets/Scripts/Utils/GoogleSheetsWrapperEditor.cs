#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

public class GoogleSheetsWrapperEditor : MonoBehaviour
{
    [MenuItem("Table/ParseFromCSV")]
    private static void ParseFromCSV()
    {
        ParseLocalization();
        ParseMods();
    }

    private static void ParseMods()
    {
        ModsContainer modsContainer = Resources.Load<ModsContainer>("Data/ModsContainer");
        modsContainer.LoadFromCSV("Assets/Data/Mods.csv");
    }

    private static void ParseLocalization()
    {
        LocalizationContainer localizationContainer = Resources.Load<LocalizationContainer>("Data/LocalizationContainer");
        localizationContainer.LoadFromCSV("Assets/Data/Localization.csv");
    }
}
#endif