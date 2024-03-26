using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizationController : MonoBehaviour
{
    private class AgentData
    {
        public TMP_Text Text;
        public int Id;
    }

    [SerializeField] private LocalizationContainer _localizationContainer;
    [SerializeField] private LanguageType _languageType;

    private List<AgentData> _localizationAgents = new List<AgentData>();

    public LanguageType LanguageType => _languageType;

    public void SubLocalization(TMP_Text localizationText, int id)
    {
        _localizationAgents.Add(new AgentData() { 
            Text = localizationText,
            Id = id 
        });

        localizationText.text = _localizationContainer.Get(id, _languageType);
    }

    public string GetText(int id)
    {
        return _localizationContainer.Get(id, _languageType);
    }

    public void ChangeLanguage(LanguageType language)
    {
        _languageType = language;

        foreach (var agent in _localizationAgents)
            agent.Text.text = _localizationContainer.Get(agent.Id, _languageType);
    }
}
