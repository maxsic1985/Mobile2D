using Profile;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class FightWindowController : BaseController
{
    #region Field
    private FightWindowView _fightWindow;
    private ProfilePlayer _profilePlayer;
    private Money _money;
    private Health _heath;
    private Force _force;
    private Banditry _banditizm;
    private Enemy _enemy;
    #endregion
    #region Life cycle
    public FightWindowController(AssetReference fightWindow, Transform transformForUI, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        LoadView(fightWindow, transformForUI);
    }

    private async void LoadView(AssetReference loadPrefab, Transform placeForUi)
    {
        var addressablePrefab = await Addressables.InstantiateAsync(loadPrefab, placeForUi).Task;
        if (addressablePrefab != null)
        {

            _fightWindow = addressablePrefab.gameObject.GetComponent<FightWindowView>();
            RefreshView();
        }
    }
    public void RefreshView()
    {
        _enemy = new Enemy("Enemy Flappy");
        _money = _profilePlayer.PlayerMoney;
        _money.Attach(_enemy);
        _heath = _profilePlayer.PlayerHealth;
        _heath.Attach(_enemy);
        _force = _profilePlayer.PlayerForce;
        _force.Attach(_enemy);
        _banditizm = _profilePlayer.PlayerBandetry;
        _banditizm.Attach(_enemy);
        SubscribeButtons();
    }
    private void SubscribeButtons()
    {
        _fightWindow.AddCoinsButton.onClick.AddListener(() => ChangeMoney(true));
        _fightWindow.MinusCoinsButton.onClick.AddListener(() => ChangeMoney(false));
        _fightWindow.AddHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _fightWindow.MinusHealthButton.onClick.AddListener(() => ChangeHealth(false));
        _fightWindow.AddPowerButton.onClick.AddListener(() => ChangePower(true));
        _fightWindow.MinusPowerButton.onClick.AddListener(() => ChangePower(false));
        _fightWindow.AddPBanditizmButton.onClick.AddListener(() => ChangeBanditizm(true));
        _fightWindow.MinusBanditizmButton.onClick.AddListener(() => ChangeBanditizm(false));
        _fightWindow.PassButton.onClick.AddListener(Pass);
        _fightWindow.FightButton.onClick.AddListener(Fight);
        _fightWindow.LeaveFightButton.onClick.AddListener(CloseWindow);
        _fightWindow.ShowPassButtonAction += OnShowPassButton;
    }
    private void ChangeBanditizm(bool isAddCount)
    {
        if (isAddCount)
        {
            _profilePlayer.CurrentCar.CurrenBandetry.Value++;
            if (_profilePlayer.CurrentCar.CurrenBandetry.Value > 2) _fightWindow.ShowPassButtonAction?.Invoke();
        }
        else
        {
            _profilePlayer.PlayerBandetry.Bandentry--;
        }
        ChangeDataWindow(_profilePlayer.CurrentCar.CurrenBandetry.Value, DataType.Banditizm);
    }
    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
        {
            _profilePlayer.CurrenMoney.Value++;
        }
        else
        {
            _profilePlayer.CurrenMoney.Value--;
        }
        ChangeDataWindow(_profilePlayer.CurrenMoney.Value, DataType.Money);
    }
    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
            _profilePlayer.CurrentCar.CurrenHealth.Value++;
        else
            _profilePlayer.CurrentCar.CurrenHealth.Value--;
        ChangeDataWindow(_profilePlayer.CurrentCar.CurrenHealth.Value, DataType.Health);
    }
    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
            _profilePlayer.CurrentCar.CurrenPower.Value++;
        else
            _profilePlayer.CurrentCar.CurrenPower.Value--;
        ChangeDataWindow(_profilePlayer.CurrentCar.CurrenPower.Value, DataType.Power);
    }
    private void Fight()
    {
        Debug.Log(_profilePlayer.CurrentCar.CurrenPower.Value >= _enemy.Power
        ? "<color=#07FF00>Win!!!</color>"
        : "<color=#FF0000>Lose!!!</color>");
    }
    private void Pass()
    {
        Debug.LogError("You Pass");
    }

    private void OnShowPassButton()
    {
        _fightWindow.PassButton.gameObject.SetActive(true);
    }
    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _money.Money = countChangeData;
                break;
            case DataType.Health:
                _heath.Health = countChangeData;
                break;
            case DataType.Power:
                _force.Power = countChangeData;
                break;
            case DataType.Banditizm:
                _banditizm.Bandentry = countChangeData;
                break;
        }
        _fightWindow.CountPowerEnemyText.text = $"Enemy Power {_enemy.Power}";

    }
    private void CloseWindow()
    {
        GameObject.Destroy(_fightWindow.gameObject);
        _profilePlayer.CurrentState.Value = GameState.Game;
    }
    protected override void OnChildDispose()
    {
        _fightWindow.AddCoinsButton.onClick.RemoveAllListeners();
        _fightWindow.MinusCoinsButton.onClick.RemoveAllListeners();
        _fightWindow.AddHealthButton.onClick.RemoveAllListeners();
        _fightWindow.MinusHealthButton.onClick.RemoveAllListeners();
        _fightWindow.AddPowerButton.onClick.RemoveAllListeners();
        _fightWindow.MinusPowerButton.onClick.RemoveAllListeners();
        _fightWindow.FightButton.onClick.RemoveAllListeners();
        _fightWindow.AddPBanditizmButton.onClick.RemoveAllListeners();
        _fightWindow.MinusBanditizmButton.onClick.RemoveAllListeners();
        _fightWindow.LeaveFightButton.onClick.RemoveAllListeners();
        _fightWindow.ShowPassButtonAction -= OnShowPassButton;
        _money.Detach(_enemy);
        _heath.Detach(_enemy);
        _force.Detach(_enemy);
        _banditizm.Detach(_enemy);
        base.OnChildDispose();
    }
    #endregion
}

