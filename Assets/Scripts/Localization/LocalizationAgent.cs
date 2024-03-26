using TMPro;
using UnityEngine;
using Zenject;

public class LocalizationAgent : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _id;

    [Inject]
    private void Construct(LocalizationController localizationController)
    {
        localizationController.SubLocalization(_text, _id);
    }
}
