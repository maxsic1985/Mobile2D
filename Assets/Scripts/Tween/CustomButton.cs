using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : Button
{
    #region Fields
    public static string ChangeButtonType => nameof(_animationButtonType);
    public static string CurveEase => nameof(_curveEase);
    public static string Duration => nameof(_duration);
    [SerializeField]
    private AnimationButtonType _animationButtonType =
    AnimationButtonType.ChangePosition;
    [SerializeField]
    private Ease _curveEase = Ease.Linear;
    [SerializeField]
    private float _duration = 0.6f;
    private float _strength = 30.0f;
    private RectTransform _rectTransform;
    private AudioSource _audioSource;
    #endregion
    #region Life cycle
    protected override void Awake()
    {
        base.Awake();
        _rectTransform = GetComponent<RectTransform>();
        _audioSource = GetComponent<AudioSource>();
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        ActivateAnimation(_animationButtonType);
        ActivateSound();
    }
    private void ActivateSound()
    {
        _audioSource.Play();
    }
    private void ActivateAnimation(AnimationButtonType animationButtonType)
    {
        switch (animationButtonType)
        {
            case AnimationButtonType.ChangeRotation:
                _rectTransform.DOShakeRotation(_duration, Vector3.forward *
                _strength).SetEase(_curveEase);
                break;
            case AnimationButtonType.ChangePosition:
                _rectTransform.DOShakeAnchorPos(_duration, Vector2.one *
                _strength).SetEase(_curveEase);
                break;

            case AnimationButtonType.ChangeScale:
                _rectTransform.DOScaleX(_duration, 1.0f).SetEase(_curveEase);
                break;
        }
    }
    #endregion
}



