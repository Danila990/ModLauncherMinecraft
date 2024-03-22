using DG.Tweening;
using System;
using UnityEngine;

public class WindowAnimation : MonoBehaviour
{
    [SerializeField] private float _rangeMove = 1000f;
    [SerializeField] private float _moveDuration = 1f;

    private Vector3 _startPosition;
    private Tween _tween;

    public void Init()
    {
        _startPosition = GetComponent<RectTransform>().position;
    }

    public void OpenAnimation()
    {
        transform.position = new Vector2(_startPosition.x + _rangeMove, transform.position.y);
        if(_tween != null ) 
            _tween.Kill();

        _tween = transform.DOMoveX(_startPosition.x, _moveDuration);
    }

    public void CloseAnimation(Action callback)
    {
        _tween = transform.DOMoveX(transform.position.x - _rangeMove, _moveDuration).OnComplete(() => callback());
    }
}
