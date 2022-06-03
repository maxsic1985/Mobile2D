using JetBrains.Annotations;
using System;
using System.Linq;

public class InventoryController : BaseController, IInventoryController
{
    #region Fields
    private readonly IInventoryModel _inventoryModel;
    private readonly IItemsRepository _itemsRepository;
    private readonly IInventoryView _inventoryWindowView;
    #endregion
    #region Life cycle
    public InventoryController(
    [NotNull] IInventoryModel inventoryModel,
    [NotNull] IItemsRepository itemsRepository,
    [NotNull] IInventoryView inventoryView)
    {
        _inventoryModel
        = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
        _itemsRepository
        = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
        _inventoryWindowView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));
        _inventoryWindowView.Init(_itemsRepository.Items.Values.ToList());

    }
    private void OnItemSelected(object sender, IItem item)
    {
        _inventoryModel.EquipItem(item);
    }
    private void OnItemDeselected(object sender, IItem item)
    {
        _inventoryModel.UnequipItem(item);
    }
    #endregion
    #region IInventoryController
    public void ShowInventory(Action callback)
    {
        _inventoryWindowView.Display();
        callback.Invoke();
    }
    public void HideInventory()
    {
        
    }
    #endregion
}