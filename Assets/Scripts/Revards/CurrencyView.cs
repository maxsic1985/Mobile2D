using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    #region Fields
    private const string WoodKey = nameof(WoodKey);
    private const string DiamondKey = nameof(DiamondKey);
    public static CurrencyView Instance;
    [SerializeField]
    private TMP_Text _currentCountWood;
    [SerializeField]
    private TMP_Text _currentCountDiamond;
#endregion
    #region Life cycle
    private int Wood
    {
        get => PlayerPrefs.GetInt(WoodKey, 0);
        set => PlayerPrefs.SetInt(WoodKey, value);
    }
    private int Diamonds
    {
        get => PlayerPrefs.GetInt(DiamondKey, 0);
        set => PlayerPrefs.SetInt(DiamondKey, value);
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        RefreshText();
        gameObject.transform.SetAsLastSibling();
    }
    public void AddWood(int value)
    {
        Wood += value;
        RefreshText();
    }
    public void AddDiamonds(int value)
    {
        Diamonds += value;
        RefreshText();
    }
    private void RefreshText()
    {
        _currentCountWood.text = Wood.ToString();
        _currentCountDiamond.text = Diamonds.ToString();
    }
    #endregion
}
