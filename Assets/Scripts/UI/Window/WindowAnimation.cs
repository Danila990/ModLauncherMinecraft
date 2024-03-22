using DG.Tweening;
using System;
using UnityEngine;

public class WindowAnimation : MonoBehaviour
{
    [SerializeField] private float _rangeMove = 1000f;
    [SerializeField] private float _moveDuration = 1f;
    [SerializeField] private bool _isCloseLeft = true;
    [SerializeField] private bool _isOpenLeft = false;

    private Vector3 _startPosition;
    private Tween _tween;

    public void Init()
    {
        _startPosition = GetComponent<RectTransform>().position;
    }

    public void OpenAnimation()
    {
        if (_tween != null)
            _tween.Kill();

        if (_isOpenLeft)
            transform.position = new Vector2(_startPosition.x - _rangeMove, transform.position.y);
        else
            transform.position = new Vector2(_startPosition.x + _rangeMove, transform.position.y);

        _tween = transform.DOMoveX(_startPosition.x, _moveDuration);
    }

    public void CloseAnimation(Action callback)
    {
        if (_isCloseLeft)
            _tween = transform.DOMoveX(transform.position.x - _rangeMove, _moveDuration).OnComplete(() => callback());
        else 
            _tween = transform.DOMoveX(transform.position.x + _rangeMove, _moveDuration).OnComplete(() => callback());
    }
}
