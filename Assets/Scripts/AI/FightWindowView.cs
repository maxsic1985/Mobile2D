using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FightWindowView : MonoBehaviour
{
    public Action ShowPassButtonAction;

    [SerializeField]
    private TMP_Text _countPowerEnemyText;
    [SerializeField]
    private Button _addCoinsButton;
    [SerializeField]
    private Button _minusCoinsButton;
    [SerializeField]
    private Button _addHealthButton;
    [SerializeField]
    private Button _minusHealthButton;
    [SerializeField]
    private Button _addPowerButton;
    [SerializeField]
    private Button _minusPowerButton;
    [SerializeField]
    private Button _addPBanditizmButton;
    [SerializeField]
    private Button _minusBanditizmButton;
    [SerializeField]
    private Button _fightButton;
    [SerializeField]
    private Button _passButton;
    [SerializeField]
    private Button _leaveButton;

    public TMP_Text CountPowerEnemyText => _countPowerEnemyText;
    public Button AddCoinsButton => _addCoinsButton;
    public Button MinusCoinsButton => _minusCoinsButton;
    public Button AddHealthButton => _addHealthButton;
    public Button MinusHealthButton => _minusHealthButton;
    public Button AddPowerButton => _addPowerButton;
    public Button MinusPowerButton => _minusPowerButton;
    public Button FightButton => _fightButton;
    public Button LeaveFightButton => _leaveButton;
    public Button AddPBanditizmButton => _addPBanditizmButton;
    public Button MinusBanditizmButton => _minusBanditizmButton;
    public Button PassButton => _passButton;

    private void Awake()
    {
        _passButton.gameObject.SetActive(false);
    }
}

