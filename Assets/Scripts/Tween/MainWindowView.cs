using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class MainWindowView : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private Button _buttonOpenPopup;
    [SerializeField]
    private PopupView _popupView;
    [SerializeField]
    private Button _buttonChangeText;
    [SerializeField]
    private Text _changeText;
    #endregion
    #region Life cycle
    private void Start()
    {
        _buttonOpenPopup.onClick.AddListener(_popupView.ShowPopup);
        _buttonChangeText.onClick.AddListener(ChangeText);
    }
    private void OnDestroy()
    {
        _buttonOpenPopup.onClick.RemoveAllListeners();
        _buttonChangeText.onClick.RemoveAllListeners();
    }
    private void ChangeText()
    {
        _changeText.DOText("I Like Unity", 1.0f).SetEase(Ease.Linear);
    }
    #endregion
}