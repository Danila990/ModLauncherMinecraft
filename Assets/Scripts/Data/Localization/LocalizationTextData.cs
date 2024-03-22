using UnityEngine;

public class LocalizationTextData
{
    [SerializeField] private string _id;
    [SerializeField] private LocalizationData _data;

    public string Id => _id;
    public LocalizationData Data => _data;
}
