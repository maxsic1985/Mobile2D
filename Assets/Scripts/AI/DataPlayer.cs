using System.Collections.Generic;

public abstract class DataPlayer
{
    private string _titleData;
    private int _countMoney = 0;
    private float _countSpeed = 3f;
    private int _countHealth = 10;
    private int _countPower = 5;
    private int _banditizm = 1;

    private List<IEnemy> _enemies = new List<IEnemy>();
    protected DataPlayer(string titleData)
    {
        _titleData = titleData;
    }
    public void Attach(IEnemy enemy)
    {
        _enemies.Add(enemy);
    }
    public void Detach(IEnemy enemy)
    {
        _enemies.Remove(enemy);
    }
    protected void Notify(DataType dataType)
    {
        foreach (var investor in _enemies)
            investor.Update(this, dataType);
    }
    public string TitleData => _titleData;
    public int Money
    {
        get => _countMoney;
        set
        {
            if (_countMoney != value)
            {
                _countMoney = value;
                Notify(DataType.Money);
            }
        }
    }
    public float Speed
    {
        get => _countSpeed;
        set
        {
            if (_countSpeed != value)
            {
                _countSpeed = value;
                Notify(DataType.Money);
            }
        }
    }
    public int Health
    {
        get => _countHealth;
        set
        {
            if (_countHealth != value)
            {
                _countHealth = value;
                Notify(DataType.Health);
            }
        }
    }
    public int Power
    {
        get => _countPower;
        set
        {
            if (_countPower != value)
            {
                _countPower = value;
                Notify(DataType.Power);
            }
        }
    }
    public int Bandentry
    {
        get => _banditizm;
        set
        {
            if (_banditizm != value)
            {
                _banditizm = value;
                Notify(DataType.Banditizm);
            }
        }
    }
}

