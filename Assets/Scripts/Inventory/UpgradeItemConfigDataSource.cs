
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName ="ItemMenu/Upgrate", order = 2)]
public class UpgradeItemConfigDataSource : ScriptableObject
{
    public UpgradeItemConfig[] itemConfigs;
}