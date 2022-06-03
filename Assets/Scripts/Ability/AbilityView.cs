using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class AbilityView : MonoBehaviour, IAbilityCollectionView
{
    #region Field
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Transform _layout;
    [SerializeField] private AbilityItemView _itemView;
    public List<AbilityItemView> _abilityItemViews = new List<AbilityItemView>(4);
    #endregion
    #region Life cycle
    public void Show()
    {
        _canvasGroup.alpha = 1;
    }
    public void Hide()
    {
        _canvasGroup.alpha = 0;
    }
    public event EventHandler<IItem> UseRequested;
    public void Display(IReadOnlyList<IItem> abilityItems)
    {
        foreach (var abilka in abilityItems)
        {
            var view = Instantiate<AbilityItemView>(_itemView, _layout);
            view.Init(abilka);
            _abilityItemViews.Add(view);
            view.OnClick += OnRequested;

        }
    }
    private void OnRequested(IItem item)
    {
        UseRequested?.Invoke(this, item);
    }
    #endregion
}

