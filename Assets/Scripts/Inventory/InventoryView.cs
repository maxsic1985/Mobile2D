using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Mobile.Resourses.Path;
using Profile;
public class InventoryView : MonoBehaviour, IInventoryView
{
    #region Fields
    public event Action<IItem> Selected;
    public event Action<IItem> Deselected;
    private List<IItem> _itemInfoCollection;
    private List<GameObject> _itemsObjectsView = new List<GameObject>();
    private InventoryItemView _itemView;
    private ProfilePlayer _playerProfile;
    #endregion
    #region IInventoryView
    public void Init(List<IItem> items)
    {
        _playerProfile = FindObjectOfType<Root>().GetComponent<Root>().ProfilePlayer;
        _itemInfoCollection = new List<IItem>();
        _itemInfoCollection = items;
        foreach (var item in _itemInfoCollection)
        {
            _itemsObjectsView.Add(GameObject.Instantiate(ResourceLoader.LoadPrefab(ResoursesPath._ItemviewPath), transform.GetChild(0), false));

            _itemsObjectsView.LastOrDefault().transform.GetChild(0).GetComponent<Text>().text = item.Info.Title;
            _itemsObjectsView.LastOrDefault().transform.GetChild(1).GetComponent<Image>().sprite = item.Info.Sprite;
            _itemsObjectsView.LastOrDefault().transform.GetChild(2).GetComponent<Text>().text = $"{item.Info.UpgradeType}+ {item.Info.Value.ToString()}";
            _itemsObjectsView.LastOrDefault().transform.GetChild(3).GetComponent<Text>().text = $"Price: {item.Info.Price.ToString()}";

            _itemView = _itemsObjectsView.LastOrDefault().GetComponent<InventoryItemView>();
            _itemView.Init(item);
            _itemView.OnClick += OnSelected;

        }
        gameObject.SetActive(false);
    }
    public void Display()
    {
        if (gameObject.activeSelf) gameObject.SetActive(false);
        else gameObject.SetActive(true);

    }
    protected virtual void OnSelected(IItem e)
    {
        Debug.Log(e.Info.Title);
        Debug.Log(e.Locked);
        e.Locked = false;
    }
    protected virtual void OnDeselected(IItem e)
    {

    }
    #endregion
}