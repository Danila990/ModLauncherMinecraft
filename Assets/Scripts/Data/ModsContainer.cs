using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Localization.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "ModsContainer", menuName = "Container/ModsContainer")]
public class ModsContainer : ScriptableObject
{
    [SerializeField] private List<ModData> _modsData;

    public List<ModData> ModsData => _modsData;

    public ModData Get(int id)
    {
        if (TryGetMod(id, out ModData modData))
            return modData;

        Debug.LogError("Id error: " + id);
        return default;
    }

    public void LoadFromCSV(string filePath)
    {
        _modsData.Clear();

        using var reader = new StreamReader(filePath, System.Text.Encoding.UTF8);
        bool isFirst = true;
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null) continue;
            if (isFirst)
            {
                isFirst = false;
                continue;
            }

            string[] splitLine = line.Split(';');

            ModData modData = new ModData();
            modData.Id = int.Parse(splitLine[0]);
            modData.IdName = int.Parse(splitLine[1]);
            modData.IdDescription = int.Parse(splitLine[2]);
            modData.PathIconPreview = splitLine[3];
            modData.PathIconDescription = splitLine[4];

            _modsData.Add(modData);
        }
    }

    private bool TryGetMod(int id, out ModData modData)
    {
        modData = _modsData.FirstOrDefault(mod => mod.Id == id);

        if (modData == null)
            return false;
        else
            return true;
    }
}