using NorskaLib.Spreadsheets;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocalizationContainer", menuName = "LocalizationContainer")]
public class LocalizationContainer : SpreadsheetsContainerBase
{
    [SpreadsheetContent]
    [SerializeField] private LocalizationContent _content;

    public LocalizationContent Content => _content;

    public string GetText(string id, E_LanguageType language)
    {
        foreach (LocalizationData LocalizationData in _content.LocalizationText)
        {
            if (LocalizationData.Id.Equals(id))
            {
                switch (language)
                {
                    case E_LanguageType.Ru:
                        return LocalizationData.Ru;
                    case E_LanguageType.En:
                        return LocalizationData.En;

                    default:
                        Debug.LogError("incorrect language");
                        break;
                }
            }
        }

        Debug.LogError("incorrect id");
        return null;
    }
}

[Serializable]
public class LocalizationContent
{
    [SpreadsheetPage("Localization")]
    public List<LocalizationData> LocalizationText;
}

[Serializable]
public class LocalizationData
{
    public string Id;
    public string Ru;
    public string En;
}