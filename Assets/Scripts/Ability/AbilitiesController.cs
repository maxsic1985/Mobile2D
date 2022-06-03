using JetBrains.Annotations;
using System;

public class AbilitiesController : BaseController
{
    #region Field
    private readonly IInventoryModel _inventoryModel;
    private readonly IRepository<int, IAbility> _abilityRepository;
    private readonly ItemsRepository _items;
    private readonly IAbilityCollectionView _abilityCollectionView;
    private readonly IAbilityActivator _abilityActivator;
#endregion
    #region Life cycle
    public AbilitiesController(
    [NotNull] IAbilityActivator abilityActivator,
    [NotNull] IInventoryModel inventoryModel,
    [NotNull] IRepository<int, IAbility> abilityRepository,
    [NotNull] IAbilityCollectionView abilityCollectionView,
    [NotNull] ItemsRepository itemsRepository)
    {
        _abilityActivator = abilityActivator ?? throw new
        ArgumentNullException(nameof(abilityActivator));
        _inventoryModel = inventoryModel ?? throw new
        ArgumentNullException(nameof(inventoryModel));
        _abilityRepository = abilityRepository ?? throw new
        ArgumentNullException(nameof(abilityRepository));
        _abilityCollectionView = abilityCollectionView ?? throw new
        ArgumentNullException(nameof(abilityCollectionView));
        _abilityCollectionView.UseRequested += OnAbilityUseRequested;
        SetupView(_abilityCollectionView);
        ShowAbilities();
    }
    private void OnAbilityUseRequested(object sender, IItem e)
    {
        if (_abilityRepository.Content.TryGetValue(e.Id, out var ability))
            ability.Apply(_abilityActivator);
    }
    private void SetupView(IAbilityCollectionView view)
    {
        view.UseRequested += OnAbilityUseRequested;
    }
    private void CleanupView(IAbilityCollectionView view)
    {
        view.UseRequested -= OnAbilityUseRequested;
    }
    public void ShowAbilities()
    {
        if (_items==null)
        {
            return;
        }
        foreach (var item in _items.Items.Values)
        {
            _inventoryModel.EquipItem(item);
        }
        _abilityCollectionView.Display(_inventoryModel.GetEquippedItems());
        _abilityCollectionView.Show();
    }
    #endregion
}
