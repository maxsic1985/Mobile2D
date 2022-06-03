public class PowerUpgrateHandler : IUpgradeCarHandler
{
    #region Fields
    private readonly int _power;
    #endregion
    #region Life cycle
    public PowerUpgrateHandler(int power)
    {
        _power = power;
    }
    #endregion
    #region IUpgradeHandler
    public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
    {
        upgradableCar.Power = _power;
        return upgradableCar;
    }
    #endregion
}
