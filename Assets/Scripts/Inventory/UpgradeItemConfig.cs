
using UnityEngine;
[CreateAssetMenu(fileName = "UpdrateItem", menuName = "ItemMenu/ConfigItem", order = 1)]
public class UpgradeItemConfig : ScriptableObject
{
    public ItemConfig itemConfig;
    [SerializeField] private UpgradeType type;
    public int value;
    public int price;
    public int Id => itemConfig.id;
    public UpgradeType UpgrtType => type;
}