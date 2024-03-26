using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LocalizationContainer", menuName = "Container/LocalizationContainer")]
public class LocalizationContainer : ScriptableObject
{
    [Serializable]
    private class LocalizationText
    {
        public int Id;
        public LocalizationData LocalizationData;
    }

    [SerializeField] private List<LocalizationText> _localization = new List<LocalizationText>();

    public string Get(int id, LanguageType languageType)
    {
        if(TryGetLocalization(id, out LocalizationData localizationData))
            switch (languageType)
            {
                case LanguageType.Ru:
                    return localizationData.Ru;

                case LanguageType.En:
                    return localizationData.En;

                default:
                    Debug.LogError("LanguageType error: " + languageType);
                    return null;
            }

        Debug.LogError("Id error: " + id);
        return default;
    }

    public void LoadFromCSV(string filePath)
    {
        _localization.Clear();

        using var reader = new StreamReader(filePath, System.Text.Encoding.UTF8);
        bool isFirst = true;
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null) continue;
            if (isFirst)
            {
                isFirst = false;
                continue;
            }

            string[] splitLine = line.Split(';');

            LocalizationData localizationData = new LocalizationData();
            localizationData.Ru = splitLine[1];
            localizationData.En = splitLine[2];

            _localization.Add(new LocalizationText()
            {
                Id = int.Parse(splitLine[0]),
                LocalizationData = localizationData
            });
        }
    }

    private bool TryGetLocalization(int id, out LocalizationData localizationData)
    {
        localizationData = _localization.FirstOrDefault(localization => localization.Id == id).LocalizationData;

        if(localizationData == null) 
            return false;
        else 
            return true;
    }
}
