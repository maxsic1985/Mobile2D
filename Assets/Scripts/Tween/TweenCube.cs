using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

[RequireComponent(typeof(Renderer))]
public class TweenCube : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private float _duration;
    [SerializeField]
    private int _countLoops;
    [SerializeField]
    private float _positionX;
    [SerializeField]
    private float _endScale;
    #endregion
    #region Life cycle
    private void ComplexTween()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(_positionX,
        _duration).SetLoops(_countLoops).SetEase(Ease.InExpo));
        sequence.Insert(0, transform.DOScale(_endScale, _duration));
        sequence.Insert(1, transform.DOJump(Vector3.forward, 5, 5, _duration));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            ComplexTween();
    }
    #endregion
}



