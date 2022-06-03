public class BandetryUpgrateHandler : IUpgradeCarHandler
{
    #region Fields
    private readonly int _bandetry;
    #endregion
    #region Life cycle
    public BandetryUpgrateHandler(int bandetry)
    {
        _bandetry = bandetry;
    }
    #endregion
    #region IUpgradeHandler
    public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
    {
        upgradableCar.Bandetry = _bandetry;
        return upgradableCar;
    }
    #endregion
}