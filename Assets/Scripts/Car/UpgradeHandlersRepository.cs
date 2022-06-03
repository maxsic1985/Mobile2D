using System.Collections.Generic;

public class UpgradeHandlersRepository : BaseController
{
    #region Field
    public IReadOnlyDictionary<int, IUpgradeCarHandler> UpgradeItems => _upgradeItemsMapById;
    private Dictionary<int, IUpgradeCarHandler> _upgradeItemsMapById = new Dictionary<int,
    IUpgradeCarHandler>();
    #endregion
    #region Life cycle
    public UpgradeHandlersRepository(
   UpgradeItemConfigDataSource upgradeItemConfigs)
    {
        PopulateItems(ref _upgradeItemsMapById, upgradeItemConfigs);
    }
    protected override void OnChildDispose()
    {
        _upgradeItemsMapById.Clear();
        _upgradeItemsMapById = null;
    }
    #endregion
    #region Methods
    private void PopulateItems(
    ref Dictionary<int, IUpgradeCarHandler> upgradeHandlersMapByType,
   UpgradeItemConfigDataSource configs)
    {
        foreach (var config in configs.itemConfigs)
        {
            if (upgradeHandlersMapByType.ContainsKey(config.Id)) continue;
                     upgradeHandlersMapByType.Add(config.Id, CreateHandlerByType(config));
        }
    }
    private IUpgradeCarHandler CreateHandlerByType(UpgradeItemConfig config)
    {
        switch (config.UpgrtType)
        {
            case UpgradeType.Speed:
                return new SpeedUpgradeCarHandler(config.value);
            case UpgradeType.Power:
                return new PowerUpgrateHandler(config.value);
            case UpgradeType.Bandetry:
                return new BandetryUpgrateHandler(config.value);
            default:
                return StubUpgradeCarHandler.Default;
        }
    }
    #endregion
}
