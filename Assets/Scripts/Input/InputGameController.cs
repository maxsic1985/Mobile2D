using CarInput;
using Tools;
using UnityEngine;

public class InputGameController : BaseController
{
    #region Field
    private readonly InputType _inputType;
    private BaseInputView _view;
    #endregion
    #region Life cycle
    public InputGameController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, Car car, InputType inputType)
    {
        _inputType = inputType;
        _view = LoadView();
        _view.Init(leftMove, rightMove, car.Speed);
    }
    private ResourcePath GetPath(InputType inputType)
    {
        ResourcePath _viewPath;
        switch (inputType)
        {
            case InputType.TOUCH:
                _viewPath = new ResourcePath { PathResource = "Prefabs/TouchPad" };
                break;
            case InputType.SWIPE:
                _viewPath = new ResourcePath { PathResource = "Prefabs/SwipeControl" };
                break;
            case InputType.CROSSINPUT:
                _viewPath = new ResourcePath { PathResource = "Prefabs/StickControl" };
                break;
            case InputType.ACCESEL:
                _viewPath = new ResourcePath { PathResource = "Prefabs/TouchPad" };
                break;
            default:
                _viewPath = new ResourcePath { PathResource = "Prefabs/TouchPad" };
                break;
        }
        return _viewPath;
    }
    private BaseInputView LoadView()
    {
        var objView = Object.Instantiate(ResourceLoader.LoadPrefab(GetPath(_inputType)));
        AddGameObjects(objView);

        return objView.GetComponent<BaseInputView>();
    }
    #endregion
}

