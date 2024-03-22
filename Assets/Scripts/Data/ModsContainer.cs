using UnityEngine;

[CreateAssetMenu(fileName = "ModsContainer", menuName = "Mods/ModsContainer")]
public class ModsContainer : ScriptableObject
{
    [SerializeField] private ModData[] _modsData;

    public ModData[] ModsData => _modsData;
}


