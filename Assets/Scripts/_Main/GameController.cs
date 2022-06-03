using Tools;
using CarInput;
using Profile;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController
{
    #region Life cycle
    public GameController(ProfilePlayer profilePlayer, IReadOnlyList<AbilityItemConfig> configs, InventoryModel model, Transform root)
    {
        var leftMoveDiff = new SubscriptionProperty<float>();
        var rightMoveDiff = new SubscriptionProperty<float>();
        
        var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
        AddController(tapeBackgroundController);

        var gameInputType = InputType.SWIPE;
        var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar, gameInputType);
        AddController(inputGameController);
    }
    #endregion
}

