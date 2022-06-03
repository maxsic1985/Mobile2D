using System;
using UnityEngine;
using UnityEngine.UI;

public class AbilityItemView : MonoBehaviour
{
    #region Field
    [SerializeField] private Button _button;
    public event Action<IItem> OnClick;
    private IItem _item;
    #endregion
    #region Life cycle
    private void Awake()
    {
        _button.onClick.AddListener(Click);
    }
    public void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
    public void Init(IItem item)
    {
        _item = item;
    }
    private void Click()
    {
        OnClick?.Invoke(_item);
    }
    #endregion
}