using Tools;

public class Car : IUpgradableCar
{
    #region
    private readonly int _defaulHealth;
    private readonly float _defaultSpeed;
    private readonly int _defaultPower;
    private readonly int _defaultBandetry;
    #endregion
    #region Life cycle
    public Car(float speed, int health, int power, int bandetry)
    {
        _defaultSpeed = speed;
        _defaulHealth = health;
        _defaultPower = power;
        _defaultBandetry = bandetry;

        CurrenSpeed = new SubscriptionProperty<float>();
        CurrenSpeed.Value = _defaultSpeed;
        CurrenHealth = new SubscriptionProperty<int>();
        CurrenHealth.Value = _defaulHealth;
        CurrenPower = new SubscriptionProperty<int>();
        CurrenPower.Value = _defaultPower;
        CurrenBandetry = new SubscriptionProperty<int>();
        CurrenBandetry.Value = _defaultBandetry;

        Restore();
    }
    public SubscriptionProperty<float> CurrenSpeed { get; set; }
    public SubscriptionProperty<int> CurrenHealth { get; set; }
    public SubscriptionProperty<int> CurrenPower { get; set; }
    public SubscriptionProperty<int> CurrenBandetry { get; set; }
    #endregion
    #region IUpgradableCar
    public int Health { get { return CurrenHealth.Value; } set { CurrenHealth.Value = value; } }
    public float Speed { get { return CurrenSpeed.Value; } set { CurrenSpeed.Value = value; } }
    public int Power { get { return CurrenPower.Value; } set { CurrenPower.Value = value; } }
    public int Bandetry { get { return CurrenBandetry.Value; } set { CurrenBandetry.Value = value; } }

    public void Restore()
    {
        Health = _defaulHealth;
        Speed = _defaultSpeed;
        Power = _defaultPower;
        Bandetry = _defaultBandetry;

    }
    #endregion
}
