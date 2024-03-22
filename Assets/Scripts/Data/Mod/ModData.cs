using UnityEngine;

[CreateAssetMenu(fileName = "ModData", menuName = "Mods/ModData")]
public class ModData : ScriptableObject
{
    [SerializeField] private string _idName;
    [SerializeField] private string _idDescription;
    [SerializeField] private Sprite _iconPreview;
    [SerializeField] private Sprite _iconDescription;

    public string IdName => _idName;
    public string IdDescription => _idDescription;
    public Sprite IconPreview => _iconPreview;
    public Sprite IconDescription => _iconDescription;
}
