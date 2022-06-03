using UnityEngine;
class Enemy : IEnemy
{
    #region Field
    private const int KCoins = 5;
    private const float KPower = 2f;
    private const int MaxHealthPlayer = 20;
    private string _name;
    private int _moneyPlayer;
    private int _healthPlayer;
    private int _powerPlayer;
    private int _banditizmPlayer;
    #endregion
    #region Life cycle
    public Enemy(string name)
    {
        _name = name;
    }
    public int Power
    {
        get
        {
            var kHealth = _healthPlayer > MaxHealthPlayer ? 100 : 5;

            var power = 1 + (int)((_moneyPlayer / kHealth) + (_powerPlayer / KPower));
            return power;
        }
    }
    #endregion
    #region IEnemy
    public void Update(DataPlayer dataPlayer, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _moneyPlayer = dataPlayer.Money;
                break;
            case DataType.Health:
                _healthPlayer = dataPlayer.Health;
                break;
            case DataType.Power:
                _powerPlayer = dataPlayer.Power;
                break;
            case DataType.Banditizm:
                _banditizmPlayer = dataPlayer.Bandentry;
                break;
        }
        Debug.Log($"Notified {_name} change to {dataPlayer}");
    }
    #endregion
}
