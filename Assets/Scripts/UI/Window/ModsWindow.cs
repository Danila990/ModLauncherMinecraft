using UnityEngine;

public class ModsWindow : Window
{
    [SerializeField] private ModsContainer _modsContainer;
    [SerializeField] private ModPanel _modPanelPrefab;
    [SerializeField] private Transform _content;

    protected override void Awake()
    {
        base.Awake();

        CreateModPanels();
    }

    private void CreateModPanels()
    {
        foreach (ModData modData in _modsContainer.ModsData)
        {
            ModPanel modPanel = Instantiate(_modPanelPrefab, _content);
            modPanel.SetupPanel(modData);
        }
    }
}
