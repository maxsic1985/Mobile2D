using UnityEngine;
using UnityEngine.AddressableAssets;

public class CurrencyController
{
    private CurrencyView _currencyView;
    public CurrencyController(AssetReference currencyView, Transform placeUI)
    {
        LoadView(currencyView, placeUI);
    }
    private async void LoadView(AssetReference loadPrefab, Transform placeForUi)
    {
        var addressablePrefab = await Addressables.InstantiateAsync(loadPrefab, placeForUi).Task;
        if (addressablePrefab != null)
        {

            _currencyView = addressablePrefab.gameObject.GetComponent<CurrencyView>();

        }
    }
    public void CloseWindow()
    {
        GameObject.Destroy(_currencyView.gameObject);
    }
}
