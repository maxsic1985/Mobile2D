using System.Collections.Generic;

public class ItemsRepository : BaseController, IItemsRepository
{
    #region Fields
    public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;
    private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();
    #endregion
    #region Life cycle
    public ItemsRepository(
    List<UpgradeItemConfig> upgradeItemConfigs)
    {
        PopulateItems(ref _itemsMapById, upgradeItemConfigs);
    }
    protected override void OnChildDispose()
    {
        _itemsMapById.Clear();
        _itemsMapById = null;
    }
    #endregion#region Methods
    #region Methods
    private void PopulateItems(
    ref Dictionary<int, IItem> upgradeHandlersMapByType,
    List<UpgradeItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (upgradeHandlersMapByType.ContainsKey(config.itemConfig.id)) continue;
            upgradeHandlersMapByType.Add(config.itemConfig.id, CreateItem(config));
        }
    }
    private IItem CreateItem(UpgradeItemConfig config)
    {
        return new Item
        {
            Id = config.itemConfig.id,
            Locked=true,
            Info = new ItemInfo { Title = config.itemConfig.title,Value=config.value,Price=config.price, Sprite=config.itemConfig.image, UpgradeType=config.UpgrtType }
        };
    }
#endregion
}
