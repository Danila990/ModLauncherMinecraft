using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class localizationButton : MonoBehaviour
{
    [Serializable]
    private class Language
    {
        public E_LanguageType LanguageType;
        public Sprite Icon;
    }

    [SerializeField] private Language[] _languages;
    [SerializeField] private Image _icon;

    private int _currentIndex;
    private LocalizationController _localizationController;

    [Inject]
    private void Construct(LocalizationController localizationController)
    {
        _localizationController = localizationController;
    }

    private void Start()
    {
        for (int i = 0; i < _languages.Length; i++)
        {
            if (_localizationController.LanguageType.Equals(_languages[i].LanguageType))
            {
                _currentIndex = i;
                _icon.sprite = _languages[i].Icon;
                break;
            }
        }

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        if(_currentIndex < _languages.Length - 1)
            _currentIndex++;
        else
            _currentIndex = 0;

        _icon.sprite = _languages[_currentIndex].Icon;
        _localizationController.ChangeLanguage(_languages[_currentIndex].LanguageType);
    }
}
