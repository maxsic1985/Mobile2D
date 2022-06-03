using CarInput;
using Profile;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Mobile.Resourses.Path;

public class MainMenuController : BaseController
{
    #region Fields
    private readonly ProfilePlayer _profilePlayer;
    private readonly IAdsShower _adsShower;
    private MainMenuView _view;
    private CarInfoView _carview;
    private readonly TileRenderView _tileView;
    private List<AsyncOperationHandle<GameObject>> _addressablePrefabs = new
List<AsyncOperationHandle<GameObject>>();
    #endregion
    #region Life cycle
    public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer, IAdsShower adsShower, AssetReference loadPrefab, CarInfoView carInfoView)
    {
        _profilePlayer = profilePlayer;
        _adsShower = adsShower;
        LoadView(loadPrefab, placeForUi);
        _tileView = LoadTileRender(placeForUi);
        _tileView.Init(StartGame);

        _carview = carInfoView;
        _carview.Init(profilePlayer);


    }
    private TileRenderView LoadTileRender(Transform placeForUi)
    {
        var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(ResoursesPath._tileRenderPath), placeForUi, false);
        AddGameObjects(objectView);
        return objectView.GetComponent<TileRenderView>();
    }

    private async void LoadView(AssetReference loadPrefab, Transform placeForUi)
    {
        var addressablePrefab = await Addressables.InstantiateAsync(loadPrefab, placeForUi).Task;
        if (addressablePrefab != null)
        {

            _view = addressablePrefab.gameObject.GetComponent<MainMenuView>();
            AddGameObjects(addressablePrefab.gameObject);
            _view.Init(StartGame, StartBattle, GoToTheShed, DailyRewardGame);

        }
    }
    private void StartGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
        _adsShower.ShowInterstitial();
        _profilePlayer.AnalyticTools.SendMessage("start_game");
    }
    private void StartBattle()
    {
        _profilePlayer.CurrentState.Value = GameState.Fight;
        _adsShower.ShowInterstitial();
        _profilePlayer.AnalyticTools.SendMessage("start_game");
    }
    private void DailyRewardGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Rewards;
    }

    private void GoToTheShed()
    {
        _profilePlayer.CurrentState.Value = GameState.Shed;
    }
    #endregion
    #region IDisposable
    protected override void OnChildDispose()
    {
        foreach (var addressablePrefab in _addressablePrefabs)
            Addressables.ReleaseInstance(addressablePrefab);
        _addressablePrefabs.Clear();
        base.OnChildDispose();
    }
    #endregion
}

