using UnityEngine;
using UnityEngine.Events;

public class MainMenuView : MonoBehaviour
{
    #region Fields
    [SerializeField] private CustomButton _buttonStart;
    [SerializeField] private CustomButton _buttonStartBattle;
    [SerializeField] private CustomButton _buttonInventory;
    [SerializeField] private CustomButton _buttonReward;
    [SerializeField] private CustomButton _buttonExit;
    #endregion
    #region Life cycle
    public void Init(UnityAction startGame, UnityAction startBattle, UnityAction showInventoryAction, UnityAction watchReward)
    {
        _buttonStart.onClick.AddListener(startGame);
        _buttonStartBattle.onClick.AddListener(startBattle);
        _buttonInventory.onClick.AddListener(showInventoryAction);
        _buttonReward.onClick.AddListener(watchReward);
        _buttonExit.onClick.AddListener(ExitGame);

    }
    private void ExitGame()
    {
        Application.Quit();
    }

    protected void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
    }
    #endregion
}