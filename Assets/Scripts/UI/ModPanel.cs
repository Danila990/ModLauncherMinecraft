using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ModPanel : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _nameModText;

    private DescriptionModWindow _descriptionModWindow;
    private WindowController _windowController;
    private ModData _modData;

    [Inject]
    private void Construct(WindowController windowController)
    {
        _windowController = windowController;
        _descriptionModWindow = _windowController.GetWindow(E_WindowType.DescriptionMod) as DescriptionModWindow;
    }

    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void SetupPanel(ModData modData)
    {
        _modData = modData;
        _icon.sprite = _modData.IconPreview;
    }

    private void OnClick()
    {
        _descriptionModWindow.SetupWindow(_modData);
        _windowController.OpenWindow(E_WindowType.DescriptionMod);
    }
}
