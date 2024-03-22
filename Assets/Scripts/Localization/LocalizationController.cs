using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizationController : MonoBehaviour
{
    private class AgentData
    {
        public TMP_Text Text;
        public string Id;
    }

    [SerializeField] private LocalizationContainer _localizationContainer;
    [SerializeField] private E_LanguageType _languageType;

    private List<AgentData> _localizationAgents = new List<AgentData>();

    public E_LanguageType LanguageType => _languageType;

    public void SubLocalization(TMP_Text localizationText, string localizationId)
    {
        _localizationAgents.Add(new AgentData() { 
            Text = localizationText,
            Id = localizationId 
        });

        localizationText.text = _localizationContainer.GetText(localizationId, _languageType);
    }

    public string GetText(string localizationId)
    {
        return _localizationContainer.GetText(localizationId, _languageType);
    }

    public void ChangeLanguage(E_LanguageType language)
    {
        _languageType = language;

        foreach (var agent in _localizationAgents) 
        {
            agent.Text.text = _localizationContainer.GetText(agent.Id, _languageType);
        }
    }
}
