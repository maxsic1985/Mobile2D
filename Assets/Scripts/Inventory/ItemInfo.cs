using UnityEngine;
using UnityEngine.UI;
public struct ItemInfo
{
    public string Title { get; set; }
    public float Value { get; set; }
    public int Price { get; set; }
    public UpgradeType UpgradeType { get; set; }
    public Sprite Sprite { get; set; }
}
