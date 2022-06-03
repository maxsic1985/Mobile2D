using UnityEngine;

public class CarController : BaseController, IAbilityActivator
{
    #region Field
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Car" };
    private readonly CarView _carView;
    #endregion
    #region Life cycle
    public CarController()
    {
        _carView = LoadView();

    }
    private CarView LoadView()
    {
        var objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObjects(objView);

        return objView.GetComponent<CarView>();
    }
    #endregion
    #region IAbilityView
    public GameObject GetViewObject()
    {
        return _carView.gameObject;
    }
    #endregion
}

