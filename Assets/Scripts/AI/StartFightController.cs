using UnityEngine;
using Profile;

public class StartFightController : BaseController
{
    #region Field
    private StartFightView _fightViewInstance;
    private ProfilePlayer _profilePlayer;
#endregion
    #region Life cycle
    public StartFightController(Transform placeForUI, StartFightView fightView, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _fightViewInstance = GameObject.Instantiate(fightView, placeForUI);
    }
    public void RefreshView()
    {
        _fightViewInstance.StartFightButton.onClick.AddListener(StartFight);
    }
    private void StartFight()
    {
        _profilePlayer.CurrentState.Value = GameState.Fight;
    }
    protected override void OnChildDispose()
    {
        _fightViewInstance.StartFightButton.onClick.RemoveAllListeners();
        GameObject.Destroy(_fightViewInstance.gameObject);
        base.OnChildDispose();
    }
    #endregion
}