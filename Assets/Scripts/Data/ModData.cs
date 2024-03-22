using UnityEngine;

[CreateAssetMenu(fileName = "ModData", menuName = "Mods/ModData")]
public class ModData : ScriptableObject
{
    [SerializeField] private string _localizationId;
    [SerializeField] private Sprite _iconPreview;
    [SerializeField] private Sprite _iconDescription;

    public string LocalizationId => _localizationId;
    public Sprite IconPreview => _iconPreview;
    public Sprite IconDescription => _iconDescription;
}
