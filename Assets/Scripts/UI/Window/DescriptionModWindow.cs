using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionModWindow : Window
{
    [SerializeField] private Image _iconMod;
    [SerializeField] private TMP_Text _descriptionMod;
    [SerializeField] private TMP_Text _nameMod;

    public void SetupWindow(ModData modData)
    {
        _iconMod.sprite = modData.IconDescription;
    }
}
