using TMPro;
using UnityEngine;
using Zenject;

public class LocalizationAgent : MonoBehaviour
{
    [SerializeField] private TMP_Text _localizationText;
    [SerializeField] private string _localizationId;

    [Inject]
    private void Construct(LocalizationController localizationController)
    {
        localizationController.SubLocalization(_localizationText, _localizationId);
    }
}
