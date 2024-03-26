using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DescriptionModWindow : Window
{
    [SerializeField] private Image _iconMod;
    [SerializeField] private TMP_Text _descriptionMod;
    [SerializeField] private TMP_Text _nameMod;

    private LocalizationController _localizationController;

    [Inject]
    private void Construct(LocalizationController localizationController)
    {
        _localizationController = localizationController;
    }

    public void SetupWindow(ModData modData)
    {
        _iconMod.sprite = Resources.Load<Sprite>(modData.PathIconDescription);
        _nameMod.text = _localizationController.GetText(modData.IdName);
        _descriptionMod.text = _localizationController.GetText(modData.IdDescription);
    }
}
