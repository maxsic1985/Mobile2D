using Profile;
using System;
using System.Text;
using TMPro;
using UnityEngine;

public class CarInfoView : MonoBehaviour
{
    #region Fields
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _powerText;
    [SerializeField] private TextMeshProUGUI _banditryText;
    [SerializeField] private TextMeshProUGUI _speedText;
    public TextMeshProUGUI MoneyText { get => _moneyText; set => _moneyText = value; }
    public TextMeshProUGUI HealthText { get => _healthText; set => _healthText = value; }
    public TextMeshProUGUI PowerText { get => _powerText; set => _powerText = value; }
    public TextMeshProUGUI BanditryText { get => _banditryText; set => _banditryText = value; }
    public TextMeshProUGUI SpeedText { get => _speedText; set => _speedText = value; }
    #endregion
    #region Life cycle
    public void Init(ProfilePlayer dataPlayer)
    {
        UpdateViewMoney(dataPlayer.CurrenMoney.Value);
        dataPlayer.CurrenMoney.SubscribeOnChange(UpdateViewMoney);


        UpdateViewHealth(dataPlayer.CurrentCar.CurrenHealth.Value);
        dataPlayer.CurrentCar.CurrenHealth.SubscribeOnChange(UpdateViewHealth);
        dataPlayer.CurrentCar.Health = dataPlayer.CurrentCar.CurrenHealth.Value;

        UpdateViewPower(dataPlayer.CurrentCar.CurrenPower.Value);
        dataPlayer.CurrentCar.CurrenPower.SubscribeOnChange(UpdateViewPower);
        dataPlayer.CurrentCar.Power = dataPlayer.CurrentCar.CurrenPower.Value;


        UpdateViewBandetry(dataPlayer.CurrentCar.CurrenBandetry.Value);
        dataPlayer.CurrentCar.CurrenBandetry.SubscribeOnChange(UpdateViewBandetry);
        dataPlayer.CurrentCar.Bandetry = dataPlayer.CurrentCar.CurrenBandetry.Value;


        UpdateViewSpeed(dataPlayer.CurrentCar.CurrenSpeed.Value);
        dataPlayer.CurrentCar.CurrenSpeed.SubscribeOnChange(UpdateViewSpeed);
        dataPlayer.CurrentCar.Speed = dataPlayer.CurrentCar.CurrenSpeed.Value;

    }
    public void UpdateViewMoney(int money)
    {
        var moneyTxt = $"Money:  {money.ToString()}";
        _moneyText.text = moneyTxt.ToString();
    }
    private void UpdateViewBandetry(int value)
    {
        var bandetryTxt = $"Bandetry:  {value.ToString()}";
        _banditryText.text = bandetryTxt;
    }
    private void UpdateViewPower(int value)
    {
        var powerTxt = $"Power:  {value.ToString()}";
        _powerText.text = powerTxt.ToString();
    }
    private void UpdateViewHealth(int value)
    {
        var healthTxt = $"health:  {value.ToString()}";
        _healthText.text = healthTxt.ToString();
    }
    private void UpdateViewSpeed(float value)
    {
        var speedTxt = $"Speed:  {value.ToString()}";
        _speedText.text = speedTxt.ToString();
    }
    #endregion
}
